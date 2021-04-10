using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.Models
{
    public class BloodRequest
    {
        public long BloodRequestIdPk { get; set; }
        public long RequestDonorFk { get; set; }
        public long? ResponsedDonorFk { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DonationDate { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string Condition { get; set; }
        public bool IsActive { get; set; }
    }
}