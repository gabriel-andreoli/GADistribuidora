using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GADistribuidora.Domain.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllAsQueryable();
    }
}
