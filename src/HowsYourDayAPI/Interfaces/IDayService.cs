using HowsYourDayAPI.DTOs.Day;
using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Interfaces
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<Day?> GetDayAsync(int id);
        Task<IEnumerable<Day>> GetDaysForUserAsync(string userId);
        Task<Day?> AddDayForUserAsync(string userId, CreateDayDTO day);
    }
}
