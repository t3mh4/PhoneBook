using ContactMicroservice.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#nullable disable

namespace ContactMicroservice.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PhoneBookContext _dbContext;
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

        public async Task RemoveAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
