using AutoMapper;
using BloodDonorTracker.DTOs.Blood;
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
            CreateMap<CreateHealthReportDTO, HealthReport>().ReverseMap();
            CreateMap<Donor, GetBloodDonor>()
                .ForMember(des => des.HealthReportIdPk, opt => opt.MapFrom(src => src.HealthReportNav.HealthReportIdPk))
                .ForMember(des => des.BloodGroupIdFk, opt => opt.MapFrom(x => x.HealthReportNav.BloodGroupIdFk))
                .ForMember(des => des.BloodGroup, opt => opt.MapFrom(x => x.HealthReportNav.BloodGroupNav.BloodGroupName))
                .ForMember(des => des.LastDonationDate, opt => opt.MapFrom(x => x.HealthReportNav.LastDonationDate))
                .ForMember(des => des.IsAvailable, opt => opt.MapFrom(x => x.HealthReportNav.IsAvailable));
        }
    }
}