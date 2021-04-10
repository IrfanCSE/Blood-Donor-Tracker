using System;

namespace BloodDonorTracker.DTOs.HealthReport
{
    public class CreateHealthReportDTO
    {
        public long BloodGroupIdFk { get; set; }
        public long DonorIdFk { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}