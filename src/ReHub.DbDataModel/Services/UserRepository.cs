using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Extensions;
using ReHub.DbDataModel.Models;
using ReHub.Utilities.Encryption;

namespace ReHub.DbDataModel.Services
{
    public class UserRepository : Repository<User>, IUserRepository<User>
    {
        private readonly IEncryptionProvider _provider;

        public UserRepository(PostgresDbContext dataContext, ILogger<UserRepository> logger) : base(dataContext, logger)
        {
            // TODO extract encrypt key in a safe environment
            _provider = new GenerateEncryptionProvider("rehub_encrypt_key", EncryptionAlgorithm.Aes);

        }
        public User? GetByEMail(string email) => _datacontext.GetUserByEmail<User>(email);

    }
}
