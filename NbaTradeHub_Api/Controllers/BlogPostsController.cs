using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Data.DTO;
using NbaTradeHub_Api.Data.Enteties;
using System.Security.Claims;

namespace NbaTradeHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _service;

        public BlogPostsController(IBlogPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBlogPosts(
            [FromQuery] string? title,
            [FromQuery] int? categoryId)
        {
            var blogPosts = _service.GetBlogPosts(title, categoryId);
            return Ok(blogPosts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBlogPost([FromBody] CreateBlogPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Missing user id claims");

            var userId = int.Parse(userIdClaim);

            var blogPost = new BlogPost
            {
                Title = dto.Title,
                Text = dto.Text,
                UserId = userId,
                CategoryId = dto.CategoryId,
                CreatedDate = DateTime.Now
            };

            _service.AddBlogPost(blogPost);

            return Ok("Blog post created");
         
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdBlogPost(int id, [FromBody] UpdBlogPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var ok = _service.UpdBlogPost(id, dto, userId);
            if (!ok) 
                return Forbid();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid ID is required");
            }

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var ok = _service.DeleteBlogPost(id, userId);
            if (!ok) return Forbid();

            return NoContent();
        }
    }
}
