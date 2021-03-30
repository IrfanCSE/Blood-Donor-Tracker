using System;

namespace BloodDonorTracker.Models
{
    public class BlackList
    {
        public long BlackListIdPk { get; set; }
        public long DonorIdFk { get; set; }
        public Donor DonorNav { get; set; }
        public DateTime ActionDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}