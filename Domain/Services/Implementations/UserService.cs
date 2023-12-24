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

        public Task<User> GetByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(x => x.Id == id);
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
