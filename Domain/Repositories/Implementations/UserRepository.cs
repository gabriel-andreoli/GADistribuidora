using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GADistribuidora.Domain.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GADistribuidoraContext context) : base(context) { }

        public User GetByEmailAsNoTracking(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Email == email && !x.Deleted);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && !x.Deleted);
        }


        public async Task<User> GetByEmailAsNoTrackingAsync(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && !x.Deleted);
        }
    }
}
