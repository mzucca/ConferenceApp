using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Extensions;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public class DoctorRepository : Repository<Doctor>, IUserRepository<Doctor>
    {
        public DoctorRepository(PostgresDbContext dataContext, ILogger<DoctorRepository> logger) : base(dataContext, logger)
        {
            logger.LogDebug("Creating doctor repository");
        }

        public Doctor? GetByEMail(string email) => _dataContext.GetUserByEmail<Doctor>(email);

    }
}
