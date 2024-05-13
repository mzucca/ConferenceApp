using Rehub.Authorization.Models;

namespace Rehub.Authorization.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        UserDefinition GetUserCredentials(string userName, string password);
    }
}
