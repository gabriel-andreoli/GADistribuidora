using GADistribuidora.Domain.Entities;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
    }
}
