using GADistribuidora.Domain.Entities;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByEmail(string email);
    }
}
