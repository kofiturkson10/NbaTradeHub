using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.DTO
{
    public class CreateBlogPostDto
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
