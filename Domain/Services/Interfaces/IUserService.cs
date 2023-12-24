using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByIdAsync(Guid id);
        Task<ICollection<UserDTO>> GetAll();
    }
}
