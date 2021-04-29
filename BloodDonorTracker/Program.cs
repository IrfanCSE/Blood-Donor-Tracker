using System;
using BloodDonorTracker.Context;
using BloodDonorTracker.Data.Seed_Data;
using BloodDonorTracker.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BloodDonorTracker
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<ApplicationContext>();
                    await context.Database.MigrateAsync();
                    await SeedDataContext.SeedDataAsync(context,loggerFactory);

                    var userManager = service.GetRequiredService<UserManager<AppUser>>();
                    var identityContext = service.GetRequiredService<IdentityContext>();
                    await identityContext.Database.MigrateAsync();
                    // await IdentitySeedContext.SeedUserAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError("Get An Error While Database Migrating From StartUp",ex);
                }
            }

            host.Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
