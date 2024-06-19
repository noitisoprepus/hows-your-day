using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("user")]
    [Authorize]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _userService;
        private readonly IDayService _dayService;

        public AppUserController(IAppUserService userService, IDayService dayService)
        {
            _userService = userService;
            _dayService = dayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AppUser>> PostUser(AppUser user)
        {
            var newUser = await _userService.PostUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, AppUser user)
        {
            if (id != user.Id)
                return BadRequest();

            try
            {
                await _userService.PutUserAsync(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
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