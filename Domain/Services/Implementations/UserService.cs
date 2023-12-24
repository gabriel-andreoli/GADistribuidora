using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.ExtensionMethods.ApiExtension;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Services.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

    }
}
