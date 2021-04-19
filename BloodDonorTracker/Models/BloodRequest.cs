using System;
using System.Collections.Generic;
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
        public long BloodGroupFK { get; set; }
        public BloodGroup BloodGroupNav { get; set; }

        [DataType(DataType.Date)]
        public DateTime DonationDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Distance { get; set; }
        public string Condition { get; set; }
        public bool? IsResponsed { get; set; }
        public bool IsActive { get; set; }
        public Alert Alert { get; set; }
        public List<DonorRequest> DonorRequests { get; set; }
    }
}