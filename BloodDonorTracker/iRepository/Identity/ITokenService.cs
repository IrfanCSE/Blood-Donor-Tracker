using BloodDonorTracker.Models;

namespace BloodDonorTracker.iRepository.Identity
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}