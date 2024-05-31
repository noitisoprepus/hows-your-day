using HowsYourDayAPI.Data;
using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class DayController : ControllerBase
    {
        private readonly HowsYourDayAppDbContext _context;

        public DayController(HowsYourDayAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            return await _context.Days.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _context.Days.FindAsync(id);
            if (day == null)
                return NotFound();
            
            return day;
        }

        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            day.LogDate = DateTime.Now;
            _context.Days.Add(day);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDay", new { id = day.Id }, day);
        }
    }
}