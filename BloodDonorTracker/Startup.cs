using BloodDonorTracker.Context;
using BloodDonorTracker.ErrorHandling;
using BloodDonorTracker.Extensions;
using BloodDonorTracker.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();

            // Database Connection
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(_configuration.GetConnectionString("IdentityConnection")));

            // Essential Extention services
            services.ApplicationServices();
            services.DependencyInjection();
            services.AddIdentityServices(_configuration);

            // Register the Swagger generator : Default : services.AddSwaggerGen()
            services.AddSwaggerGenService();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();

            // Database Connection
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(_configuration.GetConnectionString("ProdDefaultConnection")));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ProdIdentityConnection")));

            // Essential Extention services
            services.ApplicationServices();
            services.DependencyInjection();
            services.AddIdentityServices(_configuration);

            // Register the Swagger generator : Default : services.AddSwaggerGen()
            services.AddSwaggerGenService();
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

            #region --Swagger-Configuration--
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blood Donor Tracker API");
            });
            #endregion

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalrHub>("api/notify");
            });
        }
    }
}
