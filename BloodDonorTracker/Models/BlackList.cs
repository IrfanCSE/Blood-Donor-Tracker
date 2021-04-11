using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.Models
{
    public class BlackList
    {
        public long BlackListIdPk { get; set; }
        public long DonorIdFk { get; set; }
        public Donor DonorIdNav { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ActionDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}