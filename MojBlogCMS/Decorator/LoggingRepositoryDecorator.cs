using MojBlogCMS.Repositories;
using System.Linq.Expressions;

namespace MojBlogCMS.Decorator
{
    public class LoggingRepositoryDecorator<T> : IRepository<T> where T : class
    {
        private readonly IRepository<T> _innerRepository;

        public LoggingRepositoryDecorator(IRepository<T> innerRepository)
        {
            _innerRepository = innerRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            Console.WriteLine($"[LOG] Fetching all entities of type {typeof(T).Name}.");
            return await _innerRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            Console.WriteLine($"[LOG] Fetching entity of type {typeof(T).Name} with ID {id}.");
            return await _innerRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(T entity)
        {
            Console.WriteLine($"[LOG] Adding a new entity of type {typeof(T).Name}.");
            return await _innerRepository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            Console.WriteLine($"[LOG] Updating entity of type {typeof(T).Name}.");
            return await _innerRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            Console.WriteLine($"[LOG] Deleting entity of type {typeof(T).Name}.");
            return await _innerRepository.DeleteAsync(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            Console.WriteLine($"[LOG] GetAllAsync entity of type {typeof(T).Name}.");
            return _innerRepository.GetAllAsync(filter);
        }
    }
}
