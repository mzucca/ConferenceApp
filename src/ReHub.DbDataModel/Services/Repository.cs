using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseReHubModel
    {
        protected readonly PostgresDbContext _dataContext;
        protected readonly ILogger _logger;

        public Repository(PostgresDbContext dataContext, ILogger logger) 
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        #region IRepository
        public IEnumerable<TEntity> GetAlls()
        {
            return _dataContext.Set<TEntity>().ToList<TEntity>();
        }
        public IEnumerable<TEntity> GetPaged(int position, int size)
        {
            return _dataContext.Set<TEntity>()
                .Skip(position)
                .Take(size)
                .ToList<TEntity>();
        }
        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
        public TEntity? GetByID(int entityId)
        {
            var entities = _dataContext.Set<TEntity>();
            if (entities == null) return null;

            return entities.FirstOrDefault<TEntity>(u => u.Id == entityId);
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
