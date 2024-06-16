using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Services
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<Day?> GetDayAsync(int id);
        Task<IEnumerable<Day>> GetDaysForUserAsync(string userId);
        Task<Day?> AddDayForUserAsync(string userId, Day day);
    }
}
