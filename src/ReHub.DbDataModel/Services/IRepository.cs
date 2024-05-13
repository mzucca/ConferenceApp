namespace ReHub.DbDataModel.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAlls();
        IEnumerable<T> GetPaged(int position, int size);
        T GetByID(int entityId);
        void Insert(T entity);
        void Delete(int entityId);
        void Update(T entity);
        void Save();
    }
}
