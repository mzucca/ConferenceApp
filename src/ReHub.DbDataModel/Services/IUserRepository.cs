namespace ReHub.DbDataModel.Services
{
    public interface IUserRepository<T> : IRepository<T>
    {
        T? GetByEMail(string email);
    }
}
