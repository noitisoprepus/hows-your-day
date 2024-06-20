using Microsoft.AspNetCore.Identity;

namespace HowsYourDayAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}