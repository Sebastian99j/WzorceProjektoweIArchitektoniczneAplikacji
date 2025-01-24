using Microsoft.AspNetCore.Mvc;
using MojBlogCMS.Models;
using MojBlogCMS.Repositories;

namespace MojBlogCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            if (login.Username == "admin" && login.Password == "password")
            {
                var jwtService = HttpContext.RequestServices.GetService<JwtService>();
                var token = jwtService.GenerateToken(login.Username, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
