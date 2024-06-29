using System.Net.Http.Json;
using Shared.DTOs.Day;

namespace HowsYourDayApp.Services
{
    public class DayService
    {
        private readonly HttpClient _httpClient;

        public DayService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HowsYourDayApp");
        }

        public async Task<HttpResponseMessage> HasUserPostedTodayAsync()
        {
            return await _httpClient.GetAsync($"{_httpClient.BaseAddress}account/day/status");
        }

        public async Task<HttpResponseMessage> GetDaysForUserAsync()
        {
            return await _httpClient.GetAsync($"{_httpClient.BaseAddress}account/day"); 
        }

        public async Task LogDayAsync(CreateDayDTO dayDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}account/day", dayDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}