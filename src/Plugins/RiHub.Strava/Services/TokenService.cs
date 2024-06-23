
using RiHub.Strava.Models;

namespace RiHub.Strava.Services;

public class TokenService : ITokenService
{
    private readonly ILogger<TokenService> _logger;

    // TODO Save token on db
    Dictionary<string, UserTokens> _tokens=new Dictionary<string, UserTokens>();
    public TokenService(ILogger<TokenService> logger) 
    {
        _logger=logger;
        _tokens.Add("marioz63@gmail.com", new UserTokens { RefreshToken = "f962d975731480c71ad9a1f1c924b7357161f784" });
    }

    public string GetAccessToken(string userName)
    {
        if(_tokens.ContainsKey(userName)) return _tokens[userName].AccessToken;
        return null;
    }

    public string GetRefreshToken(string userName)
    {
        if (_tokens.ContainsKey(userName)) return _tokens[userName].RefreshToken;
        return null;
    }

    public void SetRefreshToken(string userName, string refreshToken)
    {
        if (_tokens.ContainsKey(userName)) _tokens[userName].RefreshToken=refreshToken;
    }

    public void UpdateAccessToken(string userName, string accessToken)
    {
        if (_tokens.ContainsKey(userName)) _tokens[userName].AccessToken=accessToken;
    }
}
