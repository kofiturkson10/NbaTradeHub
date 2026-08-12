using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.DTO
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
