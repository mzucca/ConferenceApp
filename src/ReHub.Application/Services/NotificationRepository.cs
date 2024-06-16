using Microsoft.Extensions.Logging;
using ReHub.Domain;
using ReHub.Persistence;

namespace ReHub.DbDataModel.Services;

public class NotificationRepository : Repository<Notification>, INotificationRepository
{
    public NotificationRepository(DataContext dataContext, ILogger<NotificationRepository> logger) : base(dataContext, logger)
    {
    }

    public List<NotificationRecipient> GetUserNotifications(int userId, int limit = 100, int offset = 0)
    {
        _logger.LogDebug($"Entering GetUserNotifications for user={userId} starting from:{offset} with a limit of {limit}");
        try
        {
            var notifications = _dataContext.NotificationRecipients
                .Where(n => n.UserId == userId)
                .Skip(offset)
                .Take(limit)
                .ToList<NotificationRecipient>();

            _logger.LogDebug($"Found {notifications.Count()} Notifications");
            return notifications;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Got exception for GetuserNotifications for user={userId} starting from:{offset} with a limit of {limit}");
            return new List<NotificationRecipient>();
        }
    }
}
