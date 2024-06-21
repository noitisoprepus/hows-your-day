using System.ComponentModel.DataAnnotations;

namespace HowsYourDayAPI.DTOs.Account
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}