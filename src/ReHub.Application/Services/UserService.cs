using Microsoft.Extensions.Logging;
using Rehub.Authorization.Extensions;
using ReHub.Application.Users;
using ReHub.Domain;
using ReHub.Domain.Enums;


namespace ReHub.Application.Services
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
                DisplayName = user.DisplayName,
                Role = user.Type.ToString(),
                Image = user.Image
            };
        }
        public UserDefinition GetUser(string userMail)
        {
            _logger.LogInformation("Getting user for [{userName}]", userMail);
            if (string.IsNullOrWhiteSpace(userMail))
            {
                return null;
            }
            var user = _userRepository.GetByEMail(userMail);
            if (user == null) return null;

            return new UserDefinition
            {
                Email = userMail,
                Id = user.Id,
                DisplayName = user.DisplayName,
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
        public UserDefinition RegisterUser(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email.ToLowerInvariant(),
                DisplayName = registerDto.DisplayName,
                AuthProvider = registerDto.AuthProvider.ConvertToAuthProvider(),
                Name = registerDto.Name,
                Image = registerDto.Image,
                Password = registerDto.Password,
                Type = UserType.Client, // By default all self registered user are "Clients". To be a doctor you must submit documents and approval
                UserName=registerDto.Email // TODO get rid of UserName
            };
            if (user.AuthProvider == AuthProviders.database)
                user.IsVerified = false;
            else
                user.IsVerified = true;

            _userRepository.Register(user);
            return GetUser(registerDto.Email);
        }
    }
}