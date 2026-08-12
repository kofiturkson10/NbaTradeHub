using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.DTO
{
    public class CreateCommentDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int BlogPostId { get; set; }
    }
}
