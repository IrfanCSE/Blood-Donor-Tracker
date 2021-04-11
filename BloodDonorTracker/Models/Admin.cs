namespace BloodDonorTracker.Models
{
    public class Admin
    {
        public long AdminIdPk { get; set; }
        public long AdminDonorIdFk { get; set; }
        public Donor AdminDonorNav { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}