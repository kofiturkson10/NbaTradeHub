using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.Enteties
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
