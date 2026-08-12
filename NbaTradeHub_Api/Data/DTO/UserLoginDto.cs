using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.DTO
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
