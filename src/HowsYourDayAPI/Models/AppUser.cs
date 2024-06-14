using Microsoft.AspNetCore.Identity;

namespace HowsYourDayAPI.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreationDate { get; set; }
    }
}