using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}