using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HowsYourDayAPI.DTOs.Account;
using HowsYourDayAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = new IdentityUser
            {
                UserName = registerDTO.Email,   // Username is not required anyways
                Email = registerDTO.Email
            };
            var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                    return Ok(
                        new UserDTO
                        {
                            Email = user.Email,
                            Token = _tokenService.CreateToken(user)
                        }
                    );
                else return BadRequest(roleResult.Errors);
            }
            else return BadRequest(createdUser.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = await _userManager.FindByEmailAsync(login.EmailAddress);
            if (user == null) return Unauthorized("Invalid email");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (result.Succeeded)
            {
                return Ok(
                    new UserDTO
                    {
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            }
            else return Unauthorized("Email or password not found");
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out successfully");
        }
    }
}