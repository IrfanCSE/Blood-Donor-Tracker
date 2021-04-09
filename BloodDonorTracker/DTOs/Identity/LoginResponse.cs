namespace BloodDonorTracker.DTOs.Identity
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}