using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.Donor
{
    public interface IDonor
    {
        public Task<GetDonorDTO> GetDonorById(string userId);
        public Task<ResponseMessage> CreateDonor(CreateDonorInfoDTO donor);
        public Task<ResponseMessage> UpdateLocation(string userId, double Longitude,double Latitude);
    }
}