using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GADistribuidora.Domain.Repositories.Implementations
{
    public class UserRepository : GenericRepository<UserRepository>, IUserRepository
    {
        private readonly GADistribuidoraContext _context;
        public UserRepository(GADistribuidoraContext context) : base(context) { }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && !x.Deleted);    
        }
    }
}
