using System.Diagnostics;
using RestSharp.Authenticators;
using RestSharp;
using RiHub.Strava.Oauth2;
using Microsoft.AspNetCore.WebUtilities;
using ReHub.Application.Interfaces;
using RiHub.Strava.Services;

namespace RiHub.Strava.Authentication;

/// <summary>
/// Web authenticator
/// </summary>
public class WebAuthenticator : IAuthenticator
{
    private readonly StravaClient _client;
    private readonly ITokenService _tokenService;
    private readonly string _userName;

    public WebAuthenticator(StravaClient client,
        IUserAccessor userAccessor,
        ITokenService tokenService
)
    {
        _client = client;
        _tokenService=tokenService;
        _userName = userAccessor.GetUsername();

        if (string.IsNullOrEmpty(_userName)) throw new ArgumentException("User must be authenticated to read Strava activities");
    }
    /// <summary>
    /// The access token that was received from the server.
    /// </summary>
    public string AccessToken
    {
        // TODO remove session persistency
        get => _tokenService.GetAccessToken(_userName);
        set => _tokenService.UpdateAccessToken(_userName, value);
    }

    public bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken);



    public Uri GetLoginLinkUri()
    {
        var uri = _client.GetAuthorizationUrl();
        return new Uri(uri);
    }

    public async Task<bool> OnPageLoaded(Uri uri)
    {
        if (uri.AbsoluteUri.StartsWith(_client.Configuration.RedirectUri))
        {
            Debug.WriteLine("Navigated to redirect url.");

            var parameters = QueryHelpers.ParseQuery(uri.Query)
                .ToDictionary(x => x.Key, x => string.Concat(x.Value));

            await _client.Authorize(parameters);

            if (!string.IsNullOrEmpty(_client.AccessToken))
            {
                AccessToken = _client.AccessToken;
                return true;
            }
        }

        return false;
    }

    public async Task<bool> RefreshToken()
    {
        try
        {
            await _client.UpdateAccessToken(_tokenService.GetRefreshToken(_userName));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public ValueTask Authenticate(IRestClient client, RestRequest request)
    {
        if (!string.IsNullOrEmpty(AccessToken))
            request.AddHeader("Authorization", "Bearer " + AccessToken);
        return ValueTask.CompletedTask;
    }
}