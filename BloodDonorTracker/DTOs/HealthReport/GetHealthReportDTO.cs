using System;

namespace BloodDonorTracker.DTOs.HealthReport
{
    public class GetHealthReportDTO
    {
        public long HealthReportIdPk { get; set; }
        public long BloodGroupIdFk { get; set; }
        public string BloodGroup { get; set; }
        public long DonorIdFk { get; set; }
        public string Donor { get; set; }
        
        public DateTime? LastDonationDate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}