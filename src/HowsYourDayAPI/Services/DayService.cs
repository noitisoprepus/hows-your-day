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

        public async Task<Day?> GetDayAsync(int id)
        {
            return await _context.Days.FindAsync(id);
        }

        public async Task<IEnumerable<Day>> GetDaysForUserAsync(string userId)
        {
            return await _context.Days.Where(d => d.UserId == userId).ToListAsync();
        }

        // TODO: Change to use currently logged in user
        public async Task<Day> AddDayForUserAsync(string userId, Day day)
        {
            day.DayId = Guid.NewGuid();
            day.UserId = userId;
            day.LogDate = DateTime.UtcNow;
            _context.Days.Add(day);
            await _context.SaveChangesAsync();
            return day;
        }
    }
}
