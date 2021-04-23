using AutoMapper;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.DTOs.HealthReport;
using BloodDonorTracker.Models;

namespace BloodDonorTracker.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateDonorInfoDTO, Models.Donor>().ReverseMap();
            CreateMap<Models.Donor, GetDonorDTO>()
                .ForMember(des => des.BloodGorup, opt => opt.MapFrom(src => src.HealthReportNav.BloodGroupNav.BloodGroupName))
                .ReverseMap();

            CreateMap<HealthReport, GetHealthReportDTO>()
                .ForMember(des => des.BloodGroup, opt => opt.MapFrom(src => src.BloodGroupNav.BloodGroupName))
                .ForMember(des => des.Donor, opt => opt.MapFrom(src => src.DonorNav.Name));

            CreateMap<CreateHealthReportDTO, HealthReport>().ReverseMap();
            CreateMap<Donor, GetBloodDonor>()
                .ForMember(des => des.HealthReportIdPk, opt => opt.MapFrom(src => src.HealthReportNav.HealthReportIdPk))
                .ForMember(des => des.BloodGroupIdFk, opt => opt.MapFrom(x => x.HealthReportNav.BloodGroupIdFk))
                .ForMember(des => des.BloodGroup, opt => opt.MapFrom(x => x.HealthReportNav.BloodGroupNav.BloodGroupName))
                .ForMember(des => des.LastDonationDate, opt => opt.MapFrom(x => x.HealthReportNav.LastDonationDate))
                .ForMember(des => des.IsAvailable, opt => opt.MapFrom(x => x.HealthReportNav.IsAvailable));

            CreateMap<BloodRequest, CreateBloodRequest>().ReverseMap();
            CreateMap<BloodRequest, GetBloodRequest>()
                .ForMember(des => des.BloodGroupName, opt => opt.MapFrom(src => src.BloodGroupNav.BloodGroupName))
                .ForMember(des => des.RequestDonorName, opt => opt.MapFrom(src => src.RequestDonorNav.Name))
                .ForMember(des => des.ResponsedDonorName, opt => opt.MapFrom(src => src.ResponsedDonorNav.Name));

            CreateMap<CreateDonorRequest, Models.DonorRequest>();
            CreateMap<DonorRequest, GetDonorRequest>()
                .ForMember(des => des.RequestDateTime, opt => opt.MapFrom(src => src.BloodRequestIdNav.DonationDate))
                .ForMember(des => des.RequestTime, opt => opt.MapFrom(src => src.BloodRequestIdNav.Time))
                .ForMember(des => des.RequestUserName, opt => opt.MapFrom(src => src.RequestUserIdNav.Name))
                .ForMember(des => des.RequestDonorName, opt => opt.MapFrom(src => src.RequestDonorIdNav.Name))
                .ForMember(des => des.BloodGroup, opt => opt.MapFrom(src => src.BloodRequestIdNav.BloodGroupNav.BloodGroupName));
        }
    }
}