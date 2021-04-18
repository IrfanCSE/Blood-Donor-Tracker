using System;

namespace BloodDonorTracker.DTOs.Blood
{
    public class CreateBloodRequest
    {
        public long BloodRequestIdPk { get; set; }
        public long RequestDonorFk { get; set; }
        public long BloodGroupFK { get; set; }
        public DateTime DonationDate { get; set; }
        public string Time { get; set; }
        public string Condition { get; set; }
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}