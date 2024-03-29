using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorTracker.Context;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.Donor;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Repository.Donor
{
    public class Donor : IDonor
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public Donor(IMapper mapper, ApplicationContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> CreateDonor(CreateDonorInfoDTO donor)
        {
            try
            {
                if (donor == null) throw new Exception("please fill all information");

                var info = await _context.Donors.Where(x => x.UserIdFk == donor.UserIdFk).FirstOrDefaultAsync();

                if (info != null)
                {
                    info.Address = donor.Address;
                    info.IsActive = true;
                    info.Phone = donor.Phone;
                    // info.Latitude = donor.Latitude;
                    // info.Longitude = donor.Longitude;
                    info.Name = donor.Name;
                    info.NID = donor.NID;

                    _context.Donors.Update(info);
                }
                else
                {
                    info = _mapper.Map<Models.Donor>(donor);

                    info.IsActive = true;
                    info.IsLocationUpdateAuto = true;

                    await _context.Donors.AddAsync(info);
                }

                var response = await _context.SaveChangesAsync();

                if (response == 0) throw new Exception("process failed");

                return new ResponseMessage("information saved");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetDonorDTO> GetDonorById(string userId)
        {
            try
            {
                var data = await _context.Donors.Include(x => x.HealthReportNav.BloodGroupNav).Where(x => x.UserIdFk == userId && x.IsActive == true).FirstOrDefaultAsync();

                if (data == null) throw new Exception("please give your information first");

                return _mapper.Map<GetDonorDTO>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetDonorDTO> GetDonorByNumberId(long donorId)
        {
            try
            {
                var data = await _context.Donors.Include(x => x.HealthReportNav.BloodGroupNav).Where(x => x.DonorIdPk == donorId && x.IsActive == true).FirstOrDefaultAsync();

                if (data == null) throw new Exception("No donor found");

                return _mapper.Map<GetDonorDTO>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SetSinglerConnection(string userId, string connection)
        {
            try
            {
                var data = _context.Donors.Where(x => x.UserIdFk == userId && x.IsActive == true).FirstOrDefault();

                if (data == null) throw new Exception("donor not found");

                data.WebSocketConnectionId = connection;
                _context.Donors.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage> UpdateLocation(string userId, double Longitude, double Latitude)
        {
            try
            {
                var data = await _context.Donors.Where(x => x.UserIdFk == userId && x.IsActive == true).FirstOrDefaultAsync();

                if (data == null) throw new Exception("donor not found");

                data.Longitude = Longitude;
                data.Latitude = Latitude;
                data.IsActive = true;

                _context.Donors.Update(data);
                var res = await _context.SaveChangesAsync();

                if (res == 0) throw new Exception("process failled");

                return new ResponseMessage("update location");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateMapMode(long DonorId, bool Status)
        {
            try
            {
                var donor = await _context.Donors.Where(x => x.DonorIdPk == DonorId).FirstOrDefaultAsync();
                donor.IsLocationUpdateAuto = Status;
                _context.Donors.Update(donor);
                await _context.SaveChangesAsync();
                return donor.IsLocationUpdateAuto.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}