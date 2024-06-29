namespace HowsYourDayApp.Services
{
    public class TokenService
    {
        private readonly HttpClient _httpClient;

        public TokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> TryRefreshAsync()
        {
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}token/refresh", null);
            return response;
        }
    }
}
