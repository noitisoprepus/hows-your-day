using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDayService _dayService;

        public UserController(IUserService userService, IDayService dayService)
        {
            _userService = userService;
            _dayService = dayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var newUser = await _userService.PostUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
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
        public async Task<IActionResult> DeleteUser(int id)
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

        [HttpGet("{userId:int}/day")]
        public async Task<ActionResult<IEnumerable<Day>>> GetDaysForUser(int userId)
        {
            var days = await _dayService.GetDaysForUserAsync(userId);
            return Ok(days);
        }

        [HttpPost("{userId:int}/day")]
        public async Task<ActionResult<Day>> PostDayForUser(int userId, [FromBody] Day day)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var createdDay = await _dayService.AddDayForUserAsync(userId, day);
            return CreatedAtAction(nameof(GetDaysForUser), new { userId = userId, id = createdDay.Id }, createdDay);
        }
    }
}