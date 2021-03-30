using System.Text;
using BloodDonorTracker.Context;
using BloodDonorTracker.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BloodDonorTracker.Extensions
{
    public static class ExtentionIdentityConfigure
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection service, IConfiguration config)
        {
            // var builder = service.AddIdentityCore<AppUser>();
            // builder = new IdentityBuilder(builder.UserType, builder.Services);
            // builder.AddEntityFrameworkStores<IdentityContext>();
            // builder.AddSignInManager<SignInManager<AppUser>>();

            service.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                             .AddEntityFrameworkStores<IdentityContext>()
                             .AddDefaultTokenProviders();

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = config["Token:Issuer"],
                        ValidateAudience = false,
                        //RequireExpirationTime = true
                    };
                });

            return service;
        }
    }
}