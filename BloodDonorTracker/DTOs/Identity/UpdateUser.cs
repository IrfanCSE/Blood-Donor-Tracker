using System;

namespace BloodDonorTracker.DTOs.Identity
{
    public class UpdateUser
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}