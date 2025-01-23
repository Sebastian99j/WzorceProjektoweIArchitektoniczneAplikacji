namespace MojBlogCMS.Models
{
    public interface IPost
    {
        string Title { get; set; }
        string Content { get; set; }
        string ImageUrl { get; set; }
        DateTime Published { get; set; }
    }
}
