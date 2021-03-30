namespace BloodDonorTracker.Models
{
    public class Admin
    {
        public long AdminIdPk { get; set; }
        public string AdminUserIdFk { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}