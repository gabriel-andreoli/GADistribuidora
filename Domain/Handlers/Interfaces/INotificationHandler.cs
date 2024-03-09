namespace GADistribuidora.Domain.Handlers.Interfaces
{
    public interface INotificationHandler
    {
        void AddNotification(string message);
        bool HasNotification();
        List<string> GetNotifications();
    }
}
