using BloodDonorTracker.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonorTracker.Extensions
{
    public static class ExtensionIServiceCollection
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
        }
        public static void ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddCors(opt =>
                opt.AddPolicy("CorsPolicy",
                    policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")
                )
            );
        }
    }
}