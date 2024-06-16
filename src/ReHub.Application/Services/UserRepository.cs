using Microsoft.Extensions.Logging;
using ReHub.Application.Users;
using ReHub.Domain;
using ReHub.Persistence;
using ReHub.Utilities.Encryption;

namespace ReHub.DbDataModel.Services;

public class UserRepository<T> : Repository<T>, IUserRepository<T> where T : User
{
    private readonly IEncryptionProvider _provider;

    public UserRepository(DataContext dataContext, ILogger<T> logger) : base(dataContext, logger)
    {
        // TODO extract encrypt key in a safe environment
        _provider = new GenerateEncryptionProvider("rehub_encrypt_key", EncryptionAlgorithm.Aes);

    }
    public T? GetByEMail(string email) => _dataContext.Set<T>().Where(u=>u.Email == email).FirstOrDefault();

    public void Register(T user)
    {
        // TODO
        var existing = GetByEMail(user.Email);
        if (existing != null) throw new UserExistsException(existing.Email);

        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();
    }
}
