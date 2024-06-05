using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("api/day")]
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
    }
}