using HowsYourDayApp.Services;

namespace HowsYourDayApp.HttpHandlers
{
    public class RefreshHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;

        public RefreshHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var absPath = request.RequestUri.AbsolutePath;
            if (!absPath.Contains("token") && !absPath.Contains("login") && !absPath.Contains("register"))
                await _tokenService.TryRefreshAsync();

            return await base.SendAsync(request, cancellationToken);
        }
    }
}