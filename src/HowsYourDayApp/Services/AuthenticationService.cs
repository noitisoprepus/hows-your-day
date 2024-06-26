using System.Net.Http.Json;
using Shared.DTOs.Account;

namespace HowsYourDayApp.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HowsYourDayApp");
        }


        public async Task LoginAsync(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}account/login", login);
            response.EnsureSuccessStatusCode();
        }

        public async Task LogoutAsync()
        {
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}account/logout", null);
            response.EnsureSuccessStatusCode();
        }
    }
}