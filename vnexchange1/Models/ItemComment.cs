using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class ItemComment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public string Comment { get; set; }
        public int ItemID { get; set; }
    }
}
