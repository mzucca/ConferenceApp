using ReHub.DbDataModel.Services;
using ReHub.Domain;

namespace ReHub.Application.Users;

public interface IUserRepository<T> : IRepository<T> where T : User
{
    T? GetByEMail(string email);
    void Register(T user);
}
