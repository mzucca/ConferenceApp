using RiHub.Strava.Oauth2;

namespace RiHub.Strava.Services
{
    public class AuthClientFactory : IAuthClientFactory
    {
        private readonly StravaConfig _config;
        private readonly ILogger<AuthClientFactory> _logger;

        public AuthClientFactory(StravaConfig config, ILogger<AuthClientFactory> logger)
        {
            _config = config;
            _logger = logger;
        }
        public StravaClient CreateOauth2Client(string redirectUrl)
        {

            var config = new OAuth2ClientConfiguration
            {
                ClientId = _config.ClientId,
                ClientSecret = _config.ClientSecret,
                RedirectUri = redirectUrl,
                Scope = "activity:read_all,profile:read_all"
            };
            return new StravaClient(config);
        }
    }
}
