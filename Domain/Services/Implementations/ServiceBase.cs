using GADistribuidora.Domain.Handlers.Interfaces;
using GADistribuidora.Infraestructure.Persistence;

namespace GADistribuidora.Domain.Services.Implementations
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;

        public ServiceBase(IUnitOfWork unitOfWork, INotificationHandler notificationHandler)
        {
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
        }

        public void Commit() => _unitOfWork.Commit();

        public void AddNotification(string message) => _notificationHandler.AddNotification(message);

        public bool HasNotification() => _notificationHandler.HasNotification();
    }
}
