using ReHub.Application.Users;


namespace ReHub.Infrastructure.Security
{
    public interface IExternalTokenValidator
    {
        RegisterDto GetUserFromToken(OauthToken token);
    }
}
