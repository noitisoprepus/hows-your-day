using HowsYourDayAPI.Interfaces;
using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("day")]
    [Authorize]
    public class DayController : ControllerBase
    {
        private readonly IDayService _dayService;

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            var days = await _dayService.GetDaysAsync();
            return Ok(days);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _dayService.GetDayAsync(id);
            if (day == null)
                return NotFound();
            return day;
        }

        [HttpGet("{userId}/day")]
        public async Task<ActionResult<IEnumerable<Day>>> GetDaysForUser(string userId)
        {
            var days = await _dayService.GetDaysForUserAsync(userId);
            return Ok(days);
        }

        [HttpPost("{userId}/day")]
        public async Task<ActionResult<Day>> PostDayForUser(string userId, [FromBody] Day day)
        {
            var createdDay = await _dayService.AddDayForUserAsync(userId, day);
            if (createdDay == null)
                return BadRequest("You have already posted today.");
            
            return CreatedAtAction(nameof(GetDaysForUser), new { userId }, createdDay);
        }
    }
}