using System.Net.Http.Json;
using Shared.DTOs.Account;

namespace HowsYourDayApp.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTO> LoginAsync(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync("account/login", login);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }
    }
}