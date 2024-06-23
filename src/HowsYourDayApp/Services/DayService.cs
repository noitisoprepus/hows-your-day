using System.Net.Http.Json;
using HowsYourDayApp.Models;

namespace HowsYourDayApp.Services
{
    public class DayService
    {
        private readonly HttpClient _httpClient;

        public DayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DayEntry>> GetDaysForUserAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DayEntry>>("account/day");
        }
    }
}