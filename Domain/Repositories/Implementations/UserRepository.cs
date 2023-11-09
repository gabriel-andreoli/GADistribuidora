using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GADistribuidora.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly GADistribuidoraContext _context;
        public UserRepository(GADistribuidoraContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && !x.Deleted);    
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id && !x.Deleted);
        }
    }
}
