using Microsoft.AspNetCore.Mvc;
using NbaTradeHub_Api.Data;

namespace NbaTradeHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly NbaTradesContext _context;

        public CategoryController(NbaTradesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
    }
}
