using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Services.Interfaces
{
    public interface IUserService : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
