using System;

namespace BloodDonorTracker.DTOs.Blood
{
    public class CreateBloodRequest
    {
        public long BloodRequestIdPk { get; set; }
        public long RequestDonorFk { get; set; }
        public long BloodGroupFK { get; set; }
        public DateTime DonationDate { get; set; }
        public DateTime Time { get; set; }
        public string Condition { get; set; }
    }
}