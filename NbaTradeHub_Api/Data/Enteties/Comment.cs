using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.Enteties
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}
