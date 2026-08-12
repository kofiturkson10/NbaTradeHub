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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet("post/{blogPostId}")]
        
        public IActionResult GetByPostId(int blogPostId)
        {
            var comments = _service.GetCommentsByPostId(blogPostId);
            return Ok(comments);
        }

        [Authorize]
        [HttpPost]

        public IActionResult AddComment([FromBody] CreateCommentDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var comment = new Comment
            {
                Text = dto.Text,
                UserId = userId,
                BlogPostId = dto.BlogPostId,
                CreatedDate = DateTime.Now
            };

            var ok = _service.AddComment(comment);

            if (!ok)
                return Forbid();

            return Ok("Comment created");
        }
    }
}
