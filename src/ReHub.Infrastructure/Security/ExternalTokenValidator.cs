using Google.Apis.Auth;
using Rehub.Authorization.Extensions;
using ReHub.Application.Users;
using ReHub.Domain.Enums;
using ReHub.Infrastructure.Exceptions;

namespace ReHub.Infrastructure.Security;

public class ExternalTokenValidator : IExternalTokenValidator
{
    private readonly IUserService _userService;

    public ExternalTokenValidator(IUserService userService)
    {
        _userService = userService;
    }
    public RegisterDto? GetUserFromToken(OauthToken token)
    {
        var provider = token.Provider.ConvertToAuthProvider();
        try
        {
            switch (provider)
            {
                case AuthProviders.google:
                    // Validate the token received by google
                    var payload = GoogleJsonWebSignature.ValidateAsync(token.Token,
                        new GoogleJsonWebSignature.ValidationSettings()).Result;

                    var registerDTO = new RegisterDto
                    {
                        AuthProvider = "google",
                        Email = payload.Email,
                        Image = payload.Picture,
                        Name = payload.Name,
                        DisplayName = payload.GivenName
                    };
                    return registerDTO;
                default:
                    return null;
            }
        }
        catch (InvalidJwtException exc)
        {
            throw new InvalidTokenException($"Invalid token for {token.Provider}");
        }
        catch (Exception ex) { throw ex; }
    }
}