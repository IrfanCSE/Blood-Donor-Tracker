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

                var donorList = data.AsEnumerable().OrderBy(x => x.Distance);

                pageNumber = pageNumber == 0 ? 1 : pageNumber;
                PageSize = PageSize == 0 ? 5 : PageSize;

                var newdata = donorList.Skip(((int)pageNumber - 1) * (int)PageSize).Take((int)PageSize);

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
    }
}