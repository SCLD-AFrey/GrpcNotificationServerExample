using System.Collections.Generic;

namespace GrpcNotification.Common.Server.Model
{
    public interface INotificationLogRepository
    {
        void Add(NotificationLog chatLog);
        IEnumerable<NotificationLog> GetAll();
    }
}