using MojBlogCMS.Models;

namespace MojBlogCMS.Facade
{
    public interface IPostFacade
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<int> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
        Task PublishPostAsync(int id);
        Post CreateDefaultPost();
        Task<IEnumerable<Post>> GetFilteredPostsAsync(string? title = null, string? author = null, DateTime? published = null);
    }
}
