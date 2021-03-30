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
            service.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
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