using System.Linq.Expressions;
using MojBlogCMS.Models;

namespace MojBlogCMS.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        public Task<T> GetByIdAsync(int id);
        public Task<int> AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
    }
}
