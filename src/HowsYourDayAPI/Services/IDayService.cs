using HowsYourDayAPI.Models;

namespace HowsYourDayAPI.Services
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<Day> AddDayAsync(Day day);
    }
}
