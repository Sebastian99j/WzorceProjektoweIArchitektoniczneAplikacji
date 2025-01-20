using MojBlogCMS.Models;

namespace MojBlogCMS.Strategy
{
    public class KeywordValidationStrategy : IValidationStrategy<Post>
    {
        public string Name => "Keyword";

        private readonly string[] _keywords = { "blog", "post", "content", "article" };

        public bool Validate(Post entity, out string errorMessage)
        {
            foreach (var keyword in _keywords)
            {
                if (entity.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = string.Empty;
                    return true;
                }
            }

            errorMessage = "Content must contain at least one keyword (e.g., blog, post, content, article).";
            return false;
        }
    }
}