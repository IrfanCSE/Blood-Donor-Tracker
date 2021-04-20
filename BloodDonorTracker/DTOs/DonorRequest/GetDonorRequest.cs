using System;

namespace BloodDonorTracker.DTOs.DonorRequest
{
    public class GetDonorRequest
    {
        public long DonorRequestIdPk { get; set; }
        public long BloodRequestIdFk { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public long RequestUserIdFk { get; set; }
        public string RequestUserName { get; set; }
        public long RequestDonorIdFk { get; set; }
        public string RequestDonorName { get; set; }
        public bool isActive { get; set; }
        public bool? isRead { get; set; }
        public bool? isAccept { get; set; }
        public bool? isResponse { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}