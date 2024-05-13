using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Extensions;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(PostgresDbContext dataContext, ILogger<ClientRepository> logger): base(dataContext, logger) 
        { 
        }
        public Client? GetByEMail(string email) => _datacontext.GetUserByEmail<Client>(email);
        #region IRepository

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }



        public Client GetByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            
        }
#endregion
    }
}
