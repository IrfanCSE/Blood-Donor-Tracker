using System;

namespace BloodDonorTracker.Models
{
    public class DonorRequest
    {
        public long DonorRequestIdPk { get; set; }
        public long BloodRequestIdFk { get; set; }
        public BloodRequest BloodRequestIdNav { get; set; }
        public long RequestUserIdFk { get; set; }
        public Donor RequestUserIdNav { get; set; }
        public long RequestDonorIdFk { get; set; }
        public Donor RequestDonorIdNav { get; set; }
        public bool isActive { get; set; }
        public bool? isRead { get; set; }
        public bool? isAccept { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}