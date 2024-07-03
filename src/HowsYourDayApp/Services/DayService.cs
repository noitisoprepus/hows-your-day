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

        public async Task<HttpResponseMessage> GetAverageRatingTodayAsync()
        {
            return await _httpClient.GetAsync($"{_httpClient.BaseAddress}day/average");
        }

        public async Task<HttpResponseMessage> GetUserRatingTodayAsync()
        {
            return await _httpClient.GetAsync($"{_httpClient.BaseAddress}account/day/today");
        }

        public async Task<HttpResponseMessage> LogDayAsync(CreateDayDTO dayDTO)
        {
            return await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}account/day", dayDTO);
        }
    }
}