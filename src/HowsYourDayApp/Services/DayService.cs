using System.Net.Http.Json;
using HowsYourDayApp.Models;
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

        public async Task<bool> HasUserPostedTodayAsync()
        {
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}account/day/status");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<IEnumerable<DayEntry>> GetDaysForUserAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DayEntry>>($"{_httpClient.BaseAddress}account/day");
        }

        public async Task LogDayAsync(CreateDayDTO dayDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}account/day", dayDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}