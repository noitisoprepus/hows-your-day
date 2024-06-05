using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Services
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<Day?> GetDayAsync(int id);
        Task<IEnumerable<Day>> GetDaysForUserAsync(int userId);
        Task<Day> AddDayAsync(Day day);
        Task<Day> AddDayForUserAsync(int userId, Day day);
    }
}
