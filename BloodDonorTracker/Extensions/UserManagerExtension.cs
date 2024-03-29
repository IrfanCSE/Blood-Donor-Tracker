using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloodDonorTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Extensions
{
    public static class UserManagerExtension
    {
        // public static async Task<AppUser> FindByEmailWithAddressClaimPrincipalAsync(
        //     this UserManager<AppUser> input,
        //     ClaimsPrincipal user
        //     )
        // {
        //     var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        //     return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        // }
        public static async Task<AppUser> FindByEmailWithClaimPrincipalAsync(
            this UserManager<AppUser> input,
            ClaimsPrincipal user
            )
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}