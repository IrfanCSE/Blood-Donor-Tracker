using System;

namespace BloodDonorTracker.DTOs.Blood
{
    public class GetBloodRequest
    {
        public long BloodRequestIdPk { get; set; }
        public long RequestDonorFk { get; set; }
        public string RequestDonorName { get; set; }
        public long? ResponsedDonorFk { get; set; }
        public string ResponsedDonorName { get; set; }
        public long BloodGroupFK { get; set; }
        public string BloodGroupName { get; set; }
        public DateTime DonationDate { get; set; }
        public DateTime Time { get; set; }
        public string Condition { get; set; }
        public bool IsResponsed { get; set; }
        public bool IsActive { get; set; }
    }
}