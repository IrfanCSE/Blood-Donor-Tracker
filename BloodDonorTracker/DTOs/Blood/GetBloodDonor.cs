using System;

namespace BloodDonorTracker.DTOs.Blood
{
    public class GetBloodDonor
    {
        public long DonorIdPk { get; set; }
        public string UserIdFk { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long HealthReportIdPk { get; set; }
        public long BloodGroupIdFk { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
        public double? Distance { get; set; }
    }
}