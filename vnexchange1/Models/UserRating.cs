using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class UserRating
    {
        [Key]
        public int RatingID { get; set; }
        public string UserID { get; set; }
        public string RatedBy { get; set; }
        public int Rating { get; set; }
    }
}
