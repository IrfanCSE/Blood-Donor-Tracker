using System.IdentityModel.Tokens.Jwt;
using BloodDonorTracker.Context;
using BloodDonorTracker.ErrorHandling;
using BloodDonorTracker.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BloodDonorTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Database Connection
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(_configuration.GetConnectionString("IdentityConnection")));

            // Essential Extention services
            services.ApplicationServices();
            services.DependencyInjection();
            services.AddIdentityServices(_configuration);

            // Register the Swagger generator
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            #region --Swagger-Configuration--
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BloodDonorTracker API");
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
