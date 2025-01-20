using MojBlogCMS.Models;

namespace MojBlogCMS.Strategy
{
    public class TitleLengthValidationStrategy : IValidationStrategy<Post>
    {
        public string Name => "TitleLength";

        public bool Validate(Post entity, out string errorMessage)
        {
            if (entity.Title.Length < 5 || entity.Title.Length > 100)
            {
                errorMessage = "Title must be between 5 and 100 characters.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}