using System.Security.Claims;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.Identity
{
    public interface IApplicationIdentity
    {
        public Task<ResponseMessage> RegisterUser(RegisterDTO user);
        public Task<ResponseMessage> UpdateUser(UpdateUser user);
        public Task<ResponseMessage> PasswordChange(string userId, string OldPassword, string NewPassword);
        public Task<LoginResponse> Login(string email, string password);
        public Task<LoginResponse> GetCurrentUser(ClaimsPrincipal claims);
        public Task<bool> GetEmailExist(string email);
    }
}