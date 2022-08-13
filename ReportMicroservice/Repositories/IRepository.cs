using System.Linq.Expressions;

namespace ReportMicroservice.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(Guid uuid);
        Task RemoveAsync(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> SaveAsync();
    }
}
