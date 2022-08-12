using System.Linq.Expressions;

namespace ContactMicroservice.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
