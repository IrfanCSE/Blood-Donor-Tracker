using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BloodDonorTracker.Context;
using BloodDonorTracker.Helper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BloodDonorTracker.Data.Seed_Data
{
    public class SeedDataContext
    {
        public static async Task SeedDataAsync(ApplicationContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path =Directory.GetCurrentDirectory();

                if (!context.BloodGroups.Any())
                {
                    var BloodGroups = File.ReadAllText($"{path}/Data/Json_Data/blood_groups.json");
                    var bloods = JsonConvert.DeserializeObject<List<Models.BloodGroup>>(BloodGroups);

                    await context.BloodGroups.AddRangeAsync(bloods);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedDataContext>();
                logger.LogError("An error ocured when seeding data", ex);
            }
        }
    }
}