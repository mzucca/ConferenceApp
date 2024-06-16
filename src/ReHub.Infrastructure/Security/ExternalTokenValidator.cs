using Google.Apis.Auth;
using Rehub.Authorization.Extensions;
using ReHub.Application.Users;
using ReHub.Domain.Enums;

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

        switch (provider)
        {
            case AuthProviders.google:
                // Validate the token received by google
                var payload = GoogleJsonWebSignature.ValidateAsync(token.Token,
                    new GoogleJsonWebSignature.ValidationSettings()).Result;
                var user = _userService.GetUser(payload.Email);
                if (user == null) return null;

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
}