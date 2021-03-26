using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.Identity
{
    public interface IApplicationIdentity
    {
        public Task<ResponseMessage> RegisterUser(RegisterDTO user);
    }
}