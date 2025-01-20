using MojBlogCMS.Models;

namespace MojBlogCMS.Strategy
{
    public class PostValidationStrategy : IValidationStrategy<Post>
    {
        public string Name => "Post";

        public bool Validate(Post entity, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                errorMessage = "Title cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(entity.Content))
            {
                errorMessage = "Content cannot be empty.";
                return false;
            }

            if (entity.Published > DateTime.UtcNow)
            {
                errorMessage = "Published date cannot be in the future.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
