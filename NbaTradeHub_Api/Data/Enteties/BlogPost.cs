using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.Enteties
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
