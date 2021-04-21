using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool? IsLocationUpdateAuto { get; set; }
        public ICollection<BloodRequest> BloodRequests { get; set; }
        public ICollection<BloodRequest> BloodResponsedRequests { get; set; }
        public Admin Admin { get; set; }
        public BlackList BlackList { get; set; }

        public double? Distance { get; set; }

        public List<DonorRequest> RequestReceive { get; set; }
        public List<DonorRequest> RequestSend { get; set; }
    }
}