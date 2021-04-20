using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorTracker.Context;
using BloodDonorTracker.DTOs;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.Blood;
using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Repository.Blood
{
    public class Blood : IBlood
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public Blood(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseMessage> CancelResponseOnBloodRequest(long BloodRequestIdPk, long ResponseDonorId)
        {
            try
            {
                var req = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == BloodRequestIdPk && x.ResponsedDonorFk == ResponseDonorId && x.IsActive == true).FirstOrDefaultAsync();

                if (req == null) throw new Exception("Request Missing");

                req.IsResponsed = false;
                req.ResponsedDonorFk = null;

                _context.BloodRequests.Update(req);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetBloodRequest> GetBloodRequstById(long BloodRequestId)
        {
            try
            {
                if (BloodRequestId == 0) return null;

                var req = await _context.BloodRequests.Include(x => x.BloodGroupNav).Include(x => x.RequestDonorNav).Include(x => x.ResponsedDonorNav).Where(x => x.BloodRequestIdPk == BloodRequestId).FirstOrDefaultAsync();

                if (req == null) throw new Exception("Blood Request Missing");

                if (req.Latitude == null || req.Longitude == null)
                {
                    req.Latitude = req.RequestDonorNav.Latitude;
                    req.Longitude = req.RequestDonorNav.Longitude;
                }

                return _mapper.Map<GetBloodRequest>(req);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaginationDTO<GetBloodDonor>> GetLanding(string userId, long pageNumber, long PageSize)
        {
            try
            {
                var donor = await _context.Donors.Where(x => x.UserIdFk == userId).FirstOrDefaultAsync();

                if (donor == null) throw new Exception("Donor Not Found");

                var data = _context.Donors
                    .Include(x => x.HealthReportNav.BloodGroupNav)
                    .Where(x => x.IsActive == true && x.HealthReportNav.IsAvailable == true && x.UserIdFk != donor.UserIdFk);

                if (data == null) throw new Exception("No Data Found");

                foreach (var item in data)
                {
                    item.Distance = DistanceTracker.Calculate(donor.Latitude, donor.Longitude, item.Latitude, item.Longitude, DistanceType.Metres);
                }

                var count = data.Count();

                var donorList = data.AsEnumerable().OrderBy(x => x.Distance).AsQueryable();

                pageNumber = pageNumber + 1;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var newdata = Pagination<Models.Donor>.Proccess(PageSize, pageNumber, donorList);

                var mappedData = _mapper.Map<List<GetBloodDonor>>(newdata);

                return new PaginationDTO<GetBloodDonor>
                {
                    Data = mappedData,
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

        public async Task<ResponseMessage> PostBloodRequest(CreateBloodRequest obj)
        {
            try
            {
                var time = Convert.ToDateTime(obj.Time);

                if (obj.BloodRequestIdPk == 0)
                {
                    var data = _mapper.Map<BloodRequest>(obj);
                    data.IsActive = true;
                    data.IsResponsed = false;
                    data.Time = time;
                    await _context.BloodRequests.AddAsync(data);
                }
                else
                {
                    var data = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == obj.BloodRequestIdPk && x.IsActive == true).FirstOrDefaultAsync();
                    if (data == null) throw new Exception("No Data Found");

                    if (data.IsResponsed.Value) throw new Exception("someone already responsed on this request, you can't change the request. better you remove the response or request.");

                    if (data.RequestDonorFk != obj.RequestDonorFk) throw new Exception("Warning : Unauthorized Activity Detected");

                    data.BloodGroupFK = obj.BloodGroupFK;
                    data.Condition = obj.Condition;
                    data.Time = time;
                    data.DonationDate = obj.DonationDate;
                    data.Address = obj.Address;
                    data.Latitude = obj.Latitude;
                    data.Longitude = obj.Longitude;

                    _context.BloodRequests.Update(data);
                }

                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage> RemoveBloodRequest(long BloodRequestId)
        {
            try
            {
                var req = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == BloodRequestId && x.IsActive == true).FirstOrDefaultAsync();

                if (req == null) throw new Exception("No Request Found");

                req.IsActive = false;
                _context.BloodRequests.Update(req);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage> RemoveResponseOnBloodRequest(long BloodRequestIdPk)
        {
            try
            {
                var req = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == BloodRequestIdPk && x.IsActive == true).FirstOrDefaultAsync();

                if (req == null) throw new Exception("No Request Found");

                req.IsResponsed = false;
                req.ResponsedDonorFk = null;

                _context.BloodRequests.Update(req);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage> ResponseOnBloodRequest(long BloodRequestIdPk, long ResponseDonorId)
        {
            try
            {
                var req = await _context.BloodRequests.Where(x => x.BloodRequestIdPk == BloodRequestIdPk && x.IsActive == true && x.IsResponsed == false).FirstOrDefaultAsync();

                if (req == null) throw new Exception("there is no request, or someone responsed");

                var DonorBloodGroup = await _context.Donors.Include(x => x.HealthReportNav).Where(x => x.DonorIdPk == ResponseDonorId).Select(x => x.HealthReportNav.BloodGroupIdFk).FirstOrDefaultAsync();

                if (!IsBloodMatch(DonorBloodGroup, req.BloodGroupFK)) throw new Exception("blood group not matched!");

                req.ResponsedDonorFk = ResponseDonorId;
                req.IsResponsed = true;

                _context.BloodRequests.Update(req);
                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("Process Failed");

                return new ResponseMessage("Process Success");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsBloodMatch(long DonorBloodType, long SeekerBloodType)
        {
            /*
            Determin that, Blood Type and there default value are :
             A+=1, A-=2, B+=3, B-=4, O+=5, O-=6, AB+=7, AB-=8;
            */
            // if (SeekerBloodType == BloodGroup.A_positive || SeekerBloodType == BloodGroup.A_negative || SeekerBloodType == BloodGroup.O_positive || SeekerBloodType == BloodGroup.O_negative)

            if (SeekerBloodType == (long)Helper.BloodGroup.A_positive)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.A_positive ||
                        DonorBloodType == (long)Helper.BloodGroup.A_negative ||
                          DonorBloodType == (long)Helper.BloodGroup.O_positive ||
                          DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.A_negative)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.A_negative || DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.B_positive)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.B_positive ||
                        DonorBloodType == (long)Helper.BloodGroup.B_negative ||
                          DonorBloodType == (long)Helper.BloodGroup.O_positive ||
                          DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.B_negative)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.B_negative || DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.O_positive)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.O_positive || DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.O_negative)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.O_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.AB_negative)
            {
                if (DonorBloodType == (long)Helper.BloodGroup.A_negative || DonorBloodType == (long)Helper.BloodGroup.B_negative || DonorBloodType == (long)Helper.BloodGroup.O_negative || DonorBloodType == (long)Helper.BloodGroup.AB_negative)
                    return true;
            }

            else if (SeekerBloodType == (long)Helper.BloodGroup.AB_positive)
                return true;

            return false;
        }

        public async Task<PaginationDTO<GetBloodRequest>> GetBloodRequestLanding(string userId, long pageNumber, long PageSize)
        {
            try
            {
                var data = _context.BloodRequests.Include(x => x.BloodGroupNav).Include(x => x.RequestDonorNav).Include(x => x.ResponsedDonorNav).Where(x => x.RequestDonorNav.UserIdFk == userId).OrderByDescending(x => x.BloodRequestIdPk);

                if (data == null) throw new Exception("you didn't make any request yet");

                var count = await data.CountAsync();
                pageNumber = pageNumber + 1;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var pagingData = Pagination<BloodRequest>.Proccess(PageSize, pageNumber, data);

                var mapData = _mapper.Map<List<GetBloodRequest>>(pagingData);

                return new PaginationDTO<GetBloodRequest>
                {
                    Data = mapData,
                    PageNumber = pageNumber,
                    PageSize = PageSize,
                    Total = count
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaginationDTO<GetBloodRequest>> GetBloodResponsedLanding(string userId, long pageNumber, long PageSize)
        {
            try
            {
                var responsed = await _context.Donors.Where(x => x.UserIdFk == userId).FirstOrDefaultAsync();

                if (responsed == null) throw new Exception("User Not Found");

                var data = _context.BloodRequests.Include(x => x.BloodGroupNav).Include(x => x.RequestDonorNav).Where(x => x.ResponsedDonorFk == responsed.DonorIdPk).OrderByDescending(x => x.BloodRequestIdPk);

                var count = await data.CountAsync();
                pageNumber = pageNumber + 1;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var pagingData = Pagination<BloodRequest>.Proccess(PageSize, pageNumber, data);

                var mapData = _mapper.Map<List<GetBloodRequest>>(pagingData);

                return new PaginationDTO<GetBloodRequest>
                {
                    Data = mapData,
                    PageNumber = pageNumber,
                    PageSize = PageSize,
                    Total = count
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaginationDTO<GetBloodRequest>> GetAvailableBloodReqeustLanding(string userId, long pageNumber, long PageSize)
        {
            try
            {
                var donor = await _context.Donors.Where(x => x.UserIdFk == userId).FirstOrDefaultAsync();

                if (donor == null) throw new Exception("User Not Found");

                var data = _context.BloodRequests.Include(x => x.BloodGroupNav).Include(x => x.RequestDonorNav).Include(x => x.ResponsedDonorNav).Where(x => x.IsActive == true && x.RequestDonorFk != donor.DonorIdPk);

                foreach (var item in data)
                {
                    if (item.Latitude == null || item.Longitude == null)
                    {
                        item.Latitude = item.RequestDonorNav.Latitude;
                        item.Longitude = item.RequestDonorNav.Longitude;
                    }

                    item.Distance = DistanceTracker.Calculate(donor.Latitude, donor.Longitude, item.Latitude.Value, item.Longitude.Value, DistanceType.Metres);

                    item.Address += $".[ {item.Distance} meter ]";
                }

                var donorList = data.AsEnumerable().OrderBy(x => x.Distance).AsQueryable();


                var count = await data.CountAsync();
                pageNumber = pageNumber + 1;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var pagingData = Pagination<BloodRequest>.Proccess(PageSize, pageNumber, donorList);

                var mapData = _mapper.Map<List<GetBloodRequest>>(pagingData);

                return new PaginationDTO<GetBloodRequest>
                {
                    Data = mapData,
                    PageNumber = pageNumber,
                    PageSize = PageSize,
                    Total = count
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}