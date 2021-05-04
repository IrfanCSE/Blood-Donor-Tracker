using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorTracker.Context;
using BloodDonorTracker.DTOs;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository;
using BloodDonorTracker.iRepository.DonorRequest;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Repository.DonorRequest
{
    public class DonorRequest : IDonorRequest
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<SignalrHub, IHubClient> _hub;

        public DonorRequest(ApplicationContext context, IMapper mapper, IHubContext<SignalrHub, IHubClient> hub)
        {
            _hub = hub;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseMessage> AcceptOrDeclain(long DonorRequestId, long DonorId, bool Status)
        {
            try
            {
                var data = await _context.DonorRequests.Where(x => x.DonorRequestIdPk == DonorRequestId).FirstOrDefaultAsync();

                if (data == null) throw new Exception("Data Not Found");

                if (Status)
                    await new Blood.Blood(_context, _mapper).ResponseOnBloodRequest(data.BloodRequestIdFk, DonorId);

                data.isAccept = Status;
                data.isRead = true;
                data.isActive = false;

                _context.DonorRequests.Update(data);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CancelDonorRequest(long DonorRequestId)
        {
            try
            {
                var data = await _context.DonorRequests.Where(x => x.DonorRequestIdPk == DonorRequestId).FirstOrDefaultAsync();

                if (data == null) throw new Exception("Data Not Found");

                data.isActive = false;
                _context.DonorRequests.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> CountOfNotRead(long DonorRequest)
        {
            var check = await _context.Donors.Where(x => x.DonorIdPk == DonorRequest).FirstOrDefaultAsync();
            if (check == null) return 0;
            return await _context.DonorRequests.Where(x => x.RequestDonorIdFk == DonorRequest && x.isActive == true && x.isRead == false).CountAsync();
        }

        public async Task<GetDonorRequest> GetDonorRequestById(long DonorRequestId)
        {
            try
            {
                var data = await _context.DonorRequests
                    .Include(x => x.RequestUserIdNav)
                    .Include(x => x.BloodRequestIdNav.BloodGroupNav)
                    .Include(x => x.RequestDonorIdNav)
                    .Where(x => x.DonorRequestIdPk == DonorRequestId)
                    .FirstOrDefaultAsync();

                if (data == null) throw new Exception("Data Not Found");

                return _mapper.Map<GetDonorRequest>(data);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetDonorRequest>> GetDonorRequests(long DonorId)
        {
            try
            {
                var data = await _context.DonorRequests
                    .Include(x => x.RequestUserIdNav)
                    .Include(x => x.RequestDonorIdNav)
                    .Include(x => x.BloodRequestIdNav.BloodGroupNav)
                    .Where(x => x.RequestDonorIdFk == DonorId && x.isActive == true)
                    .OrderByDescending(x => x.DonorRequestIdPk)
                    .ToListAsync();

                return _mapper.Map<List<GetDonorRequest>>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaginationDTO<GetDonorRequest>> GetDonorSendRequests(long DonorId, long pageNumber, long PageSize)
        {
            try
            {
                var data = _context.DonorRequests
                    .Include(x => x.RequestUserIdNav)
                    .Include(x => x.RequestDonorIdNav)
                    .Include(x => x.BloodRequestIdNav.BloodGroupNav)
                    .Where(x => x.RequestUserIdFk == DonorId);

                var count = await data.CountAsync();
                pageNumber = pageNumber + 1;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var pagingData = Pagination<Models.DonorRequest>.Proccess(PageSize, pageNumber, data);

                var mapData = _mapper.Map<List<GetDonorRequest>>(pagingData);

                return new PaginationDTO<GetDonorRequest>
                {
                    Data = mapData,
                    PageNumber = pageNumber,
                    PageSize = PageSize,
                    Total = count
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage> PostDonorRequest(CreateDonorRequest obj)
        {
            try
            {
                var exist = await _context.DonorRequests.Where(x => x.BloodRequestIdFk == obj.BloodRequestIdFk && x.RequestDonorIdFk == obj.RequestDonorIdFk && x.isActive == true).FirstOrDefaultAsync();

                if (exist != null) throw new Exception("already send this request");

                var req = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == obj.BloodRequestIdFk && x.IsActive == true && x.IsResponsed == false).FirstOrDefaultAsync();
                if (req == null) throw new Exception("there is no request, or someone responsed");

                var donor = await _context.Donors.Include(x => x.HealthReportNav).Where(x => x.DonorIdPk == obj.RequestDonorIdFk).FirstOrDefaultAsync();

                var match = Blood.Blood.IsBloodMatch(donor.HealthReportNav.BloodGroupIdFk, req.BloodGroupFK);
                if (!match) throw new Exception("blood group not matched!");

                var data = _mapper.Map<Models.DonorRequest>(obj);

                data.isActive = true;
                data.isRead = false;
                data.RequestDateTime = DateTime.Now;

                await _context.DonorRequests.AddAsync(data);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                var user = await _context.Donors.Where(x => x.DonorIdPk == data.RequestDonorIdFk).FirstOrDefaultAsync();

                var userId = await _context.Donors.Where(x => x.DonorIdPk == data.RequestDonorIdFk).Select(x => x.WebSocketConnectionId).FirstOrDefaultAsync();

                if (userId != null)
                    await _hub.Clients.Client(userId).BroadcastMessage();

                return new ResponseMessage("Process Success");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateIsRead(long DonorRequest)
        {
            try
            {
                var data = await _context.DonorRequests.Where(x => x.DonorRequestIdPk == DonorRequest).FirstOrDefaultAsync();

                if (data == null) throw new Exception("Data Not Found");

                data.isRead = true;
                _context.DonorRequests.Update(data);
                await _context.SaveChangesAsync();

                var userId = await _context.Donors.Where(x => x.DonorIdPk == data.RequestDonorIdFk).Select(x => x.WebSocketConnectionId).FirstOrDefaultAsync();

                if (userId != null)
                    await _hub.Clients.Client(userId).BroadcastMessage();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}