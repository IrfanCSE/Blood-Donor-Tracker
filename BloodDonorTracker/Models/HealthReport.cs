using System;

namespace BloodDonorTracker.Models
{
    public class HealthReport
    {
        public long HealthReportIdPk { get; set; }
        public long DonorIdFk { get; set; }
        public long BloodGroupIdFk { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}