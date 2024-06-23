using RiHub.Strava.Models;

namespace RiHub.Strava.Services;

public interface ITokenService
{
    string GetAccessToken(string userName);
    void UpdateAccessToken(string userName, string accessToken);
    string GetRefreshToken(string userName);
    void SetRefreshToken(string userName, string refreshToken);

}
