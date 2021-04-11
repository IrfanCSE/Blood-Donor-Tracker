using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.Models
{
    public class BloodRequest
    {
        public long BloodRequestIdPk { get; set; }
        public long RequestDonorFk { get; set; }
        public Donor RequestDonorNav { get; set; }
        public long? ResponsedDonorFk { get; set; }
        public Donor ResponsedDonorNav { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DonationDate { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string Condition { get; set; }
        public bool IsActive { get; set; }
        public Alert Alert { get; set; }
    }
}