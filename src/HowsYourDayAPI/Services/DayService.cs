using HowsYourDayAPI.Data;
using HowsYourDayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayAPI.Services
{
    public class DayService: IDayService
    {
        private readonly HowsYourDayAppDbContext _context;

        public DayService(HowsYourDayAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Day>> GetDaysAsync()
        {
            return await _context.Days.ToListAsync();
        }

        public async Task<Day> AddDayAsync(Day day)
        {
            day.LogDate = DateTime.UtcNow;
            _context.Days.Add(day);
            await _context.SaveChangesAsync();
            return day;
        }
    }
}
