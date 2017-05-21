
using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(100)]
        public string CategoryName { get; set; }
        public int CategoryOrder { get; set; }
        [Required]
        public string CategoryImage { get; set; }

    }
}
