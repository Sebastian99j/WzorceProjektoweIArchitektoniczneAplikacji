using Microsoft.AspNetCore.Mvc;
using MojBlogCMS.Facade;

namespace MojBlogCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IPostFacade _blogFacade;

        public BlogController(IPostFacade blogFacade)
        {
            _blogFacade = blogFacade;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts() => Ok(await _blogFacade.GetAllPostsAsync());
    }

}
