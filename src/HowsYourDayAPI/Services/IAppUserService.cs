using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HowsYourDayAPI.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser?> GetUserAsync(string id);
        Task<IdentityResult> PostUserAsync(AppUser user);
        Task<IdentityResult> PutUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(string id);

    }
}
