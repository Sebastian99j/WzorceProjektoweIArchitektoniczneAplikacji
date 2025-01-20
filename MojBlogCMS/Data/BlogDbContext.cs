using Microsoft.EntityFrameworkCore;
using MojBlogCMS.Models;

namespace MojBlogCMS.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
