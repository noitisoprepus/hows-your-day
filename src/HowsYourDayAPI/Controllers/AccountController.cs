using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HowsYourDayAPI.Interfaces;
using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Account;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = new AppUser
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
                            Id = user.Id,
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

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(
                    new UserDTO
                    {
                        Id = user.Id,
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