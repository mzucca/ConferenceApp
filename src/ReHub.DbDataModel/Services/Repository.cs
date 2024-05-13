using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;

namespace ReHub.DbDataModel.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PostgresDbContext _datacontext;
        protected readonly ILogger _logger;

        public Repository(PostgresDbContext dataContext, ILogger logger) 
        {
            _datacontext = dataContext;
            _logger = logger;
        }

        #region IRepository
        public IEnumerable<TEntity> GetAlls()
        {
            return _datacontext.Set<TEntity>().ToList<TEntity>();
        }
        public IEnumerable<TEntity> GetPaged(int position, int size)
        {
            return _datacontext.Set<TEntity>()
                .Skip(position)
                .Take(size)
                .ToList<TEntity>();
        }
        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
        public TEntity GetByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
