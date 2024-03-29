using BloodDonorTracker.Helper;
using BloodDonorTracker.iRepository.Blood;
using BloodDonorTracker.iRepository.Donor;
using BloodDonorTracker.iRepository.DonorRequest;
using BloodDonorTracker.iRepository.HealthReport;
using BloodDonorTracker.iRepository.Identity;
using BloodDonorTracker.Repository.Blood;
using BloodDonorTracker.Repository.Donor;
using BloodDonorTracker.Repository.DonorRequest;
using BloodDonorTracker.Repository.HealthReport;
using BloodDonorTracker.Repository.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonorTracker.Extensions
{
    public static class ExtensionIServiceCollection
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IApplicationIdentity, ApplicationIdentity>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDonor, Donor>();
            services.AddScoped<IHealthReport, HealthReport>();
            services.AddScoped<IBlood, Blood>();
            services.AddScoped<IDonorRequest, DonorRequest>();
        }
        public static void ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // services.AddCors(opt =>
            //     opt.AddPolicy("CorsPolicy",
            //         policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
            // );
        }
    }
}