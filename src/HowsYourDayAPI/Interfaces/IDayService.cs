using HowsYourDayAPI.Models;
using Shared.DTOs.Day;

namespace HowsYourDayAPI.Interfaces
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<Day?> GetDayAsync(int id);
        Task<bool> HasUserPostedTodayAsync(string userId);
        Task<IEnumerable<Day>> GetDaysForUserAsync(string userId);
        Task<Day?> AddDayForUserAsync(string userId, CreateDayDTO day);
    }
}
