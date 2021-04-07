using System;
using Microsoft.AspNetCore.Identity;

namespace BloodDonorTracker.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long? DonorFk { get; set; }
        public Donor DonorNav { get; set; }
    }
}