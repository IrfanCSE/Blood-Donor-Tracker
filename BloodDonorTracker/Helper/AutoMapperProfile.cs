using AutoMapper;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.DTOs.HealthReport;
using BloodDonorTracker.Models;

namespace BloodDonorTracker.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateDonorInfoDTO, Models.Donor>().ReverseMap();
            CreateMap<GetDonorDTO, Models.Donor>().ReverseMap();
            CreateMap<GetHealthReportDTO, HealthReport>().ReverseMap();
        }
    }
}