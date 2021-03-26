using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Donor;

namespace BloodDonorTracker.iRepository.Donor
{
    public interface IDonor
    {
         public Task<GetDonorDTO> GetDonors();
    }
}