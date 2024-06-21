using System.ComponentModel.DataAnnotations;

namespace HowsYourDayAPI.DTOs.Account
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Password { get; set; }
    }   
}