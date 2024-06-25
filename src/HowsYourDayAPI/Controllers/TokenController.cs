using Microsoft.AspNetCore.Mvc;
using HowsYourDayAPI.Interfaces;
using Shared.DTOs.Account;

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
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDTO)
        {
            var newTokenDTO = await _tokenService.RefreshToken(tokenDTO);
            return Ok(newTokenDTO);

        }
    }
}