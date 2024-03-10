using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.ExtensionMethods.ApiExtension;
using GADistribuidora.Domain.Handlers.Interfaces;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Services.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository,
            INotificationHandler notificationHandler) : base(unitOfWork, notificationHandler)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmailAsNoTrackingAsync(string email)
        {
            return await _userRepository.GetByEmailAsNoTrackingAsync(email);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(x => x.Id == id);
            if (user is null)
                AddNotification("Usuário não existente.");
            return user;
        }

        public async Task<ICollection<UserDTO>> GetAll() 
        {
            var users = _userRepository.GetAllAsQueryable().Where(x => !x.Deleted);
            ICollection<UserDTO> result = new List<UserDTO>();
            foreach (var user in users)
                result.Add(user.ToUserDTO());
            return result;
        }

    }
}
