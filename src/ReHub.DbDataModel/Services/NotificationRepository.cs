using Microsoft.Extensions.Logging;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(PostgresDbContext dataContext, ILogger<NotificationRepository> logger) : base(dataContext, logger)
        {
        }
    }
}
