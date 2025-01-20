using Microsoft.EntityFrameworkCore;

namespace MojBlogCMS.Data
{
    public class BlogDbContextSingleton
    {
        private static BlogDbContext _instance;
        private static readonly object _lock = new();

        private BlogDbContextSingleton() { }

        public static BlogDbContext GetInstance(DbContextOptions<BlogDbContext> options)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BlogDbContext(options);
                    }
                }
            }
            return _instance;
        }
    }
}
