using System.Linq.Expressions;

namespace Application.Interfaces
{ 
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void RemoveAsync(T entity);
    }
}