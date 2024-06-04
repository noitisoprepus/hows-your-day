using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            var newDay = await _dayService.AddDayAsync(day);
            return CreatedAtAction("GetDay", new { id = newDay.Id }, newDay);
        }
    }
}