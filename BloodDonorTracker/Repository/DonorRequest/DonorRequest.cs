using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorTracker.Context;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.DonorRequest;
using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Repository.DonorRequest
{
    public class DonorRequest : IDonorRequest
    {
        private readonly ApplicationContext _context;
        private readonly Mapper _mapper;

        public DonorRequest(ApplicationContext context, Mapper mapper)
        {
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
                    .Where(x => x.RequestDonorIdFk == DonorId && x.isActive == true).ToListAsync();

                return _mapper.Map<List<GetDonorRequest>>(data);
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

                var data = _mapper.Map<Models.DonorRequest>(obj);

                data.isActive = true;
                data.RequestDateTime = DateTime.Now;

                await _context.DonorRequests.AddAsync(data);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

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
                data.isRead = true;
                _context.DonorRequests.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}