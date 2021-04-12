namespace BloodDonorTracker.DTOs.Donor
{
    public class CreateDonorInfoDTO
    {
        public string UserIdFk { get; set; }
        public string Name { get; set; }
        public string NID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        // public double Longitude { get; set; }
        // public double Latitude { get; set; }
    }
}