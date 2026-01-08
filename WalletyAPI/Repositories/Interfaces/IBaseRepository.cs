using System.Linq;
using Microsoft.EntityFrameworkCore;
using WalletyAPI.Data;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T?> GetByIdAsync(object id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task AddAsync(T entity);
        public void Update(T entity);
        public Task Remove(T entity);
        public Task SaveChangesAsync();
        public IQueryable<T> Query();
    }
}
