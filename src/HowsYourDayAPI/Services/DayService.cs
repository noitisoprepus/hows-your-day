using HowsYourDayAPI.Data;
using HowsYourDayAPI.DTOs.Day;
using HowsYourDayAPI.Interfaces;
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

        public async Task<Day?> AddDayForUserAsync(string userId, CreateDayDTO day)
        {
            var today = DateTime.UtcNow.Date;
            var hasPostedToday = await _context.Days
                .AnyAsync(d => d.UserId == userId && d.LogDate.Date == today);
            if (hasPostedToday) return null;

            var newDay = new Day{
                DayId = Guid.NewGuid(),
                UserId = userId,
                LogDate = DateTime.UtcNow,
                Rating = day.Rating,
                Comment = day.Comment
            };
            _context.Days.Add(newDay);
            await _context.SaveChangesAsync();
            
            return newDay;
        }
    }
}
