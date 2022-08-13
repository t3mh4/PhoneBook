using ReportMicroservice.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#nullable disable

namespace ReportMicroservice.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PhoneBookContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(PhoneBookContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public virtual async Task RemoveAsync(Guid uuid)
        {
            var entity = await _dbSet.FindAsync(uuid);
            _dbSet.Remove(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            });
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}
