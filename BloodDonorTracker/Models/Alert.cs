using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.Models
{
    public class Alert
    {
        public long Id { get; set; }
        public long RequestIdFk { get; set; }
        public BloodRequest RequestIdNav { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateOfDonation { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime TimeOfDonation { get; set; }
        public bool IsActive { get; set; }
    }
}