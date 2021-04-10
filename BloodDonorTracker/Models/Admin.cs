namespace BloodDonorTracker.Models
{
    public class Admin
    {
        public long AdminIdPk { get; set; }
        public string AdminDonorIdFk { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}