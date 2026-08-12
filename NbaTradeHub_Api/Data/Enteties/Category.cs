using System.ComponentModel.DataAnnotations;

namespace NbaTradeHub_Api.Data.Enteties
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
