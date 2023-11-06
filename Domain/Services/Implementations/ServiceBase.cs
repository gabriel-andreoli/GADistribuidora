using GADistribuidora.Infraestructure.Persistance;

namespace GADistribuidora.Domain.Services.Implementations
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
