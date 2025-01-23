using System.ComponentModel.DataAnnotations;

namespace MojBlogCMS.Models
{
    public class Post : IPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public DateTime Published { get; set; }
    }
}
