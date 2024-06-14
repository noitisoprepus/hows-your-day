using HowsYourDayAPI.Data;
using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayAPI.Services
{
    public class AppUserService: IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser?> GetUserAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> PostUserAsync(AppUser user)
        {
            user.CreationDate = DateTime.UtcNow;
            return await _userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> PutUserAsync(AppUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            // TODO: Update PasswordHash

            return await _userManager.UpdateAsync(existingUser);
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            return await _userManager.DeleteAsync(user);
        }
    }
}