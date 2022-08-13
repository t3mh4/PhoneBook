using System.Linq.Expressions;

namespace PhoneBook.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task RemoveAsync(Guid uuid);
        Task RemoveAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> SaveAsync();
    }
}
