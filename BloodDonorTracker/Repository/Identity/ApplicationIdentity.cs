using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.Extensions;
using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.Identity;
using BloodDonorTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BloodDonorTracker.Repository.Identity
{
    public class ApplicationIdentity : IApplicationIdentity
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _token;
        public ApplicationIdentity(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService token)
        {
            _token = token;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public async Task<LoginResponse> GetCurrentUser(ClaimsPrincipal claim)
        {
            var user = await _userManager.FindByEmailWithClaimPrincipalAsync(claim);

            return new LoginResponse
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _token.CreateToken(user)
            };
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var appUser = await _userManager.FindByEmailAsync(email);

            if (appUser == null) throw new Exception($"Invalid Information");

            var isAuth = await _userManager.CheckPasswordAsync(appUser, password);

            if (!isAuth) throw new Exception("Invalid Information");

            var key = _token.CreateToken(appUser);

            return new LoginResponse { Email = appUser.Email, UserName = appUser.UserName, Token = key };
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