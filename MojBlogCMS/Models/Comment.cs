namespace MojBlogCMS.Models
{
    public class Comment : IPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Published { get; set; }
    }
}
