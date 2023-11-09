using GADistribuidora.Domain.Entities;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetById(Guid id);
    }
}
