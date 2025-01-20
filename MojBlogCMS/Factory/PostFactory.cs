using MojBlogCMS.Models;

namespace MojBlogCMS.Factory
{
    public class PostFactory : IPostFactory<Post>
    {
        public Post Create()
        {
            return new Post
            {
                Title = "Default Title",
                Content = "Default Content",
                ImageUrl = "Default Image",
                Published = DateTime.UtcNow
            };
        }

        public Post Create(Action<Post> configure)
        {
            var post = new Post
            {
                Title = "Default Title",
                Content = "Default Content",
                ImageUrl = "Default Image",
                Published = DateTime.UtcNow
            };

            configure?.Invoke(post);
            return post;
        }
    }
}
