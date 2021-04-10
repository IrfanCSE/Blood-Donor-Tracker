using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.Models
{
    public class HealthReport
    {
        public long HealthReportIdPk { get; set; }
        public long BloodGroupIdFk { get; set; }
        public BloodGroup BloodGroupNav { get; set; }
        public long DonorIdFk { get; set; }
        public Donor DonorNav { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? LastDonationDate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}