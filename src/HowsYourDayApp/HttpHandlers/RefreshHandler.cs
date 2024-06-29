using System.Net;
using HowsYourDayApp.Services;
using Microsoft.AspNetCore.Components;

namespace HowsYourDayApp.HttpHandlers
{
    public class RefreshHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;
        private readonly NavigationManager _navigationManager;

        public RefreshHandler(TokenService tokenService, NavigationManager navigationManager)
        {
            _tokenService = tokenService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var absPath = request.RequestUri.AbsolutePath;
            if (!absPath.Contains("token") && !absPath.Contains("login") && !absPath.Contains("register"))
            {
                var result = await _tokenService.TryRefreshAsync();
                if (!result.IsSuccessStatusCode &&
                    result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/login");
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        ReasonPhrase = "Unauthorized - Token refresh failed"
                    };
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}