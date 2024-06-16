namespace ReHub.Application.Users
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        UserDefinition GetUserCredentials(string email, string password);
        UserDefinition GetUser(string email);
        UserDefinition RegisterUser(RegisterDto registerDto);
    }
}
