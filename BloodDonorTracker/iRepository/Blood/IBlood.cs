using System.Threading.Tasks;
using BloodDonorTracker.DTOs;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.Blood
{
    public interface IBlood
    {
        // public Task<ResponseMessage> GetLanding(double FromLat, double FromLong);
        public Task<PaginationDTO<GetBloodDonor>> GetLanding(string userId,long pageNumber,long PageSize);
    }
}