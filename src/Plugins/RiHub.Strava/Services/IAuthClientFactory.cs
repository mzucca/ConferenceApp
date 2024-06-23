using RiHub.Strava.Oauth2;

namespace RiHub.Strava.Services
{
    public interface IAuthClientFactory
    {
        StravaClient CreateOauth2Client(string redirectUrl);
    }
}
