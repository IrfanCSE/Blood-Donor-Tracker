using System.Collections.Generic;

namespace BloodDonorTracker.Models
{
    public class BloodGroup
    {
        public long BloodGroupIdPk { get; set; }
        public string BloodGroupName { get; set; }
        public List<HealthReport> HealthReports { get; set; }
    }
}