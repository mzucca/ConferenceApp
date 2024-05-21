using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public interface INotificationRepository : IRepository<Notification>
    {
        public List<NotificationRecipient> GetUserNotifications(int userId, int limit = 100, int offset = 0);
    }
}
