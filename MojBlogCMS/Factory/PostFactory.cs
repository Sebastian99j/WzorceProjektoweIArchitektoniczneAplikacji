using MojBlogCMS.Models;

namespace MojBlogCMS.Factory
{
    public enum ComponentType
    {
        POST, COMMENT, BLOG
    }

    public class PostFactory : IPostFactory<IPost>
    {
        public IPost Create(ComponentType type = ComponentType.POST)
        {
            switch (type)
            {
                case ComponentType.POST:
                    return new Post
                    {
                        Title = "Default Title",
                        Content = "Default Content",
                        ImageUrl = "Default Image",
                        Published = DateTime.UtcNow
                    };

                case ComponentType.BLOG:
                    return new Blog
                    {
                        Title = "Default Blog Title",
                        Content = "Blog Content",
                        ImageUrl = "Blog Image",
                        Published = DateTime.UtcNow
                    };

                case ComponentType.COMMENT:
                    return new Comment()
                    {
                        Title = "Default Comment",
                        Content = "This is a default comment",
                        ImageUrl = null,
                        Published = DateTime.UtcNow
                    };

                default:
                    return new Post
                    {
                        Title = "Default Title",
                        Content = "Default Content",
                        ImageUrl = "Default Image",
                        Published = DateTime.UtcNow
                    };
            }
        }

        public IPost Create(Action<IPost> configure, ComponentType type = ComponentType.POST)
        {
            var post = Create(type);
            configure?.Invoke(post);
            return post;
        }
    }
}
