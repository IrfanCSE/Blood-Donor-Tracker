using System;
using System.Linq;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.Identity;
using BloodDonorTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace BloodDonorTracker.Repository.Identity
{
    public class ApplicationIdentity : IApplicationIdentity
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationIdentity(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public async Task<ResponseMessage> RegisterUser(RegisterDTO user)
        {
            try
            {
                if (user == null) throw new Exception("You Should Fill Your Information");

                if (user.Password != user.ConfirmPassword) throw new Exception("Confirm Password Not Matched");

                var userIdentity = new AppUser
                {
                    Email = user.Email,
                    NormalizedEmail = user.Email.ToUpper(),
                    UserName = user.UserName,
                    NormalizedUserName = user.UserName.ToUpper(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth
                };

                var response = await _userManager.CreateAsync(userIdentity, user.Password);

                if (!response.Succeeded) throw new Exception("Registration Filed, Because " + response.Errors.Select(x => x.Description).FirstOrDefault());

                return new ResponseMessage("Create Succesfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}