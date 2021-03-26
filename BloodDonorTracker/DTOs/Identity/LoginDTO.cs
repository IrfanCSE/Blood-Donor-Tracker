using System.ComponentModel.DataAnnotations;

namespace BloodDonorTracker.DTOs.Identity
{
    public class LoginDTO
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}