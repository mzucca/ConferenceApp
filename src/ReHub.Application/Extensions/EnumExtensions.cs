using ReHub.Domain.Enums;

namespace Rehub.Authorization.Extensions;

public static class EnumExtensions
{
    public static AuthProviders ConvertToAuthProvider(this string authProvider)
    {
        AuthProviders auth = AuthProviders.database;
        if (Enum.TryParse(authProvider.ToLowerInvariant(), out auth)) return auth;

        throw new ArgumentException($"{authProvider} is an unsupported authentication provider");

    }
}
