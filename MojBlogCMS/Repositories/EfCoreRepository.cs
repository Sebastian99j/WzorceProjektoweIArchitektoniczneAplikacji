using Microsoft.EntityFrameworkCore;
using MojBlogCMS.Data;
using System.Linq.Expressions;

namespace MojBlogCMS.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogDbContext _context;
        private DbSet<T> _entities;

        public EfCoreRepository(BlogDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _entities.FindAsync(id);

        public async Task<int> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return (int)typeof(T).GetProperty("Id")?.GetValue(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}