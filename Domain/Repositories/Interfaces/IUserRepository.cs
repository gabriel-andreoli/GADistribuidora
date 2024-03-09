using GADistribuidora.Domain.Entities;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByEmailAsNoTracking(string email);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByEmailAsNoTrackingAsync(string email);
    }
}
