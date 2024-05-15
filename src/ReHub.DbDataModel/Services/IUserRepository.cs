using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public interface IUserRepository<T> : IRepository<T> where T : User
    {
        T? GetByEMail(string email);
    }
}
