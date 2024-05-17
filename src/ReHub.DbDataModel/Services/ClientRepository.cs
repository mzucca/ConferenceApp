using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Extensions;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Extensions;

namespace ReHub.DbDataModel.Services
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(PostgresDbContext dataContext, ILogger<ClientRepository> logger): base(dataContext, logger) 
        { 
        }
        public Client? GetByEMail(string email) => _dataContext.GetUserByEmail<Client>(email);


        #region IClientRepository
        public ClientDetails GetDetails(int customerId)
        {
            return _dataContext.GetById<ClientDetails>(customerId);
        }
        #endregion
    }
}
