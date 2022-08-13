using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#nullable disable

namespace PhoneBook.Core.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TEntity> where TEntity : class
                                                   where TContext : class
    {
        protected readonly TContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(TContext dbContext)
        {
            _dbContext = dbContext;
            //_dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public virtual async Task RemoveAsync(Guid uuid)
        {
            var entity = await _dbSet.FindAsync(uuid);
            _dbSet.Remove(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                //_dbContext.Entry(entity).State = EntityState.Modified;
            });
        }

        public async Task<bool> SaveAsync()
        {
            //return await _dbContext.SaveChangesAsync() == 1;
            return true;
        }

    }
}
