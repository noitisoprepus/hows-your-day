using Microsoft.AspNetCore.Mvc;
using HowsYourDayAPI.Interfaces;
using Shared.DTOs.Account;
using Microsoft.AspNetCore.Authorization;

namespace HowsYourDayAPI.Controllers
{
    [ApiController]
    [Route("token")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<IActionResult> Refresh()
        {
            HttpContext.Request.Cookies.TryGetValue("accessToken", out var accessToken);
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
            
            var tokenDTO = new TokenDTO(accessToken, refreshToken);
            var newTokenDTO = await _tokenService.RefreshToken(tokenDTO);
            _tokenService.StoreTokensToCookie(newTokenDTO, HttpContext);
            
            return Ok();
        }
    }
}