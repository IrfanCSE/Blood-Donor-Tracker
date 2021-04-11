using System.Collections.Generic;

namespace BloodDonorTracker.Models
{
    public class Donor
    {
        public long DonorIdPk { get; set; }
        public string UserIdFk { get; set; }
        public HealthReport HealthReportNav { get; set; }
        public string Name { get; set; }
        public string NID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BloodRequest> BloodRequests { get; set; }
        public ICollection<BloodRequest> BloodResponsedRequests { get; set; }
        public Admin Admin { get; set; }
        public BlackList BlackList { get; set; }
    }
}