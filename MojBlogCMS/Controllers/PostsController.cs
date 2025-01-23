using Microsoft.AspNetCore.Mvc;
using MojBlogCMS.Facade;
using MojBlogCMS.Factory;
using MojBlogCMS.Models;
using MojBlogCMS.Repositories;
using MojBlogCMS.Strategy;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IRepository<Post> _postRepository;

    public PostsController(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }

    // GET: api/posts
    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postRepository.GetAllAsync();
        return Ok(posts);
    }

    // GET: api/posts/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    // PUT: api/posts/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        var result = await _postRepository.UpdateAsync(post);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/posts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        var result = await _postRepository.DeleteAsync(post);
        if (!result)
        {
            return BadRequest("Could not delete the post.");
        }

        return NoContent();
    }

    [HttpPost("create-default")]
    public async Task<IActionResult> CreateDefaultPost([FromServices] IPostFactory<IPost> postFactory, [FromServices] IPostFacade blogFacade)
    {
        var post = postFactory.Create();
        await blogFacade.CreatePostAsync((Post)post);
        return Ok(post);
    }

    [HttpPost("create-custom")]
    public IActionResult CreateCustomPost([FromServices] IPostFactory<IPost> postFactory, [FromServices] IPostFacade blogFacade)
    {
        var post = postFactory.Create(p =>
        {
            p.Title = "Custom Title";
            p.Content = "Custom Content";
            p.ImageUrl = "Custom Image";
            p.Published = DateTime.UtcNow.AddDays(-1);
        });
        blogFacade.CreatePostAsync((Post)post);

        return Ok(post);
    }

    [HttpPost("create-custom-full")]
    public IActionResult CreateCustomPostFull([FromServices] IPostFactory<IPost> postFactory, [FromServices] IPostFacade blogFacade, [FromBody] Post pt)
    {
        var post = postFactory.Create(p =>
        {
            p.Title = pt.Title;
            p.Content = pt.Content;
            p.ImageUrl = pt.ImageUrl;
            p.Published = DateTime.UtcNow.AddDays(-1);
        });
        blogFacade.CreatePostAsync((Post)post);

        return Ok(post);
    }

    [HttpPut("publish/{id}")]
    public async Task<IActionResult> PublishPost(int id, [FromServices] IPostFacade blogFacade)
    {
        try
        {
            await blogFacade.PublishPostAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("create-post")]
    public async Task<IActionResult> CreatePost(
        [FromServices] ValidationManager<Post> validationManager,
        [FromServices] IPostFacade blogFacade,
        [FromQuery] string strategyName,
        [FromBody] Post post)
    {
        if (!validationManager.Validate(strategyName, post, out var errorMessage))
        {
            return BadRequest(new { error = errorMessage });
        }

        await blogFacade.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }
}