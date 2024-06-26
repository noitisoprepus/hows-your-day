using Microsoft.AspNetCore.Identity;
using Shared.DTOs.Account;

namespace HowsYourDayAPI.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO, HttpContext httpContext);
        Task<SignInResult> LoginAsync(LoginDTO login, HttpContext httpContext);
        Task LogoutAsync(HttpContext httpContext);
    }
}
