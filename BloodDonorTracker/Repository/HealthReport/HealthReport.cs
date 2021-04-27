using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodDonorTracker.Context;
using BloodDonorTracker.DTOs.DDL;
using BloodDonorTracker.DTOs.HealthReport;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.HealthReport;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Repository.HealthReport
{
    public class HealthReport : IHealthReport
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public HealthReport(IMapper mapper, ApplicationContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<GetHealthReportDTO> GetHealthReportById(long donorId)
        {
            try
            {
                var info = await _context.HealthReports.Include(x => x.DonorNav).Include(x => x.BloodGroupNav).Where(x => x.DonorIdFk == donorId && x.IsActive == true).FirstOrDefaultAsync();

                if (info == null) throw new Exception("information empty");

                return _mapper.Map<GetHealthReportDTO>(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage> CreateHealthReport(CreateHealthReportDTO report)
        {
            try
            {
                if (report == null) throw new Exception("please fill all information");

                var check = await _context.Donors.Where(x => x.DonorIdPk == report.DonorIdFk).FirstOrDefaultAsync();

                if (check == null) throw new Exception("please fill your information first");

                var info = await _context.HealthReports.Where(x => x.DonorIdFk == report.DonorIdFk && x.IsActive == true).FirstOrDefaultAsync();

                if (info != null)
                {
                    info.BloodGroupIdFk = report.BloodGroupIdFk;
                    info.IsActive = true;
                    info.LastDonationDate = report.LastDonationDate;
                    info.IsAvailable = report.IsAvailable;

                    _context.HealthReports.Update(info);
                }
                else
                {
                    info = _mapper.Map<Models.HealthReport>(report);
                    info.IsActive = true;

                    await _context.HealthReports.AddAsync(info);
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

        public async Task<List<GetCommonDDLDTO>> GetBloodGroups()
        {
            try
            {
                return await _context.BloodGroups.Select(x => new GetCommonDDLDTO
                {
                    Label = x.BloodGroupName,
                    Value = x.BloodGroupIdPk
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}