using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> PostUserAsync(User user);
        Task PutUserAsync(User user);
        Task DeleteUserAsync(int id);

    }
}
