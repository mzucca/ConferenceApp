using ReHub.Application.Users;


namespace ReHub.Application.Services
{
    public interface IExternalTokenValidator
    {
        RegisterDto GetUserFromToken(OauthToken token);
    }
}
