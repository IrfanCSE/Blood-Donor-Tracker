using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.iRepository.Donor;

namespace BloodDonorTracker.Repository.Donor
{
    public class Donor : IDonor
    {
        public Task<GetDonorDTO> GetDonors()
        {
            throw new System.NotImplementedException();
        }
    }
}