using AutoMapper;
using BloodDonorTracker.DTOs.Donor;

namespace BloodDonorTracker.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateDonorInfoDTO, Models.Donor>().ReverseMap();
            CreateMap<GetDonorDTO, Models.Donor>().ReverseMap();
        }
    }
}