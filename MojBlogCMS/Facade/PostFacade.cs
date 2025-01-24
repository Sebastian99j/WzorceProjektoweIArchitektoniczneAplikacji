using MojBlogCMS.Models;
using MojBlogCMS.Repositories;

namespace MojBlogCMS.Facade
{
    public class PostFacade : IPostFacade
    {
        private readonly IRepository<Post> _postRepository;

        public PostFacade(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<int> CreatePostAsync(Post post)
        {
            return await _postRepository.AddAsync(post);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            return await _postRepository.UpdateAsync(post);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return false;

            return await _postRepository.DeleteAsync(post);
        }

        public Post CreateDefaultPost()
        {
            return new Post
            {
                Title = "Default Title",
                Content = "Default Content",
                Published = DateTime.UtcNow
            };
        }

        public async Task PublishPostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception("Post not found.");
            }

            post.Published = DateTime.UtcNow;
            await _postRepository.UpdateAsync(post);
        }

        public async Task<IEnumerable<Post>> GetFilteredPostsAsync(string? title = null, string? content = null,
            DateTime? published = null)
        {
            return await _postRepository.GetAllAsync(
                filter: p =>
                    (string.IsNullOrEmpty(title) || p.Title.Contains(title)) &&
                    (string.IsNullOrEmpty(content) || p.Content.Contains(content)) &&
                    (!published.HasValue || p.Published >= published.Value)
            );
        }
    }
}