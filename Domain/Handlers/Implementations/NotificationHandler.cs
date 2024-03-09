using GADistribuidora.Domain.Handlers.Interfaces;

namespace GADistribuidora.Domain.Handlers.Implementations
{
    public class NotificationHandler : INotificationHandler
    {
        private List<string> Notifications = new List<string>();

        public void AddNotification(string message) => Notifications.Add(message);

        public bool HasNotification() => Notifications.Any();
        public List<string> GetNotifications() => Notifications;
    }
}
