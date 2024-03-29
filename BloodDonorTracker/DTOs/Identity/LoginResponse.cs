using System;
namespace BloodDonorTracker.DTOs.Identity
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public DateTime Birthday { get; set; }
    }
}