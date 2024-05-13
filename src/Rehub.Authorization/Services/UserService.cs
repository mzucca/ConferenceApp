using Microsoft.Extensions.Logging;
using Rehub.Authorization.Models;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Services;

namespace Rehub.Authorization.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository<User> userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public UserDefinition GetUserCredentials(string userMail, string password)
        {
            _logger.LogInformation("Getting user credentials for [{userName}]", userMail);
            if (string.IsNullOrWhiteSpace(userMail))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var user = _userRepository.GetByEMail(userMail);
            if (user == null || user.Password != password)
            {
                _logger.LogInformation($"Invalid credentials for '{userMail}'");
                return null;
            }
            return new UserDefinition 
            {
                Email = userMail,
                Id = user.Id,
                Name = user.Name,
                Role = user.Type.ToString(),
            };
        }

        public bool IsAnExistingUser(string userMail)
        {
            var user = _userRepository.GetByEMail(userMail);
            if (user == null)
                return false;
            return true;
        }
    }
}