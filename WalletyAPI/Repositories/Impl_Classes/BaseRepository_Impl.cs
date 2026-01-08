using Microsoft.EntityFrameworkCore;
using WalletyAPI.Data;
using WalletyAPI.Repositories.Interfaces;

namespace WalletyAPI.Repositories.Impl_Classes
{
    public class BaseRepository_Impl<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository_Impl(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Query() => _context.Set<T>().AsQueryable();

        public async Task<T?> GetByFieldAsync(object field)
        {
            return await _context.Set<T>().FindAsync(field);
        }
    }
}