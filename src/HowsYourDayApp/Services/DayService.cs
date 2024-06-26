using System.Net.Http.Json;
using HowsYourDayApp.Models;

namespace HowsYourDayApp.Services
{
    public class DayService
    {
        private readonly HttpClient _httpClient;

        public DayService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HowsYourDayApp");
        }

        public async Task<IEnumerable<DayEntry>> GetDaysForUserAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DayEntry>>($"{_httpClient.BaseAddress}account/day");
        }
    }
}