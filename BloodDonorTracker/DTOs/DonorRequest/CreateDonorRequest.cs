namespace BloodDonorTracker.DTOs.DonorRequest
{
    public class CreateDonorRequest
    {
        // public long DonorRequestIdPk { get; set; }
        public long BloodRequestIdFk { get; set; }
        public long RequestUserIdFk { get; set; }
        public long RequestDonorIdFk { get; set; }
    }
}