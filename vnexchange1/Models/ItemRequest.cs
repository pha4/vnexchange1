
using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class ItemRequest
    {
        [Key]
        public int RequestID { get; set; }
        [Required, MaxLength(100)]
        public string ItemID { get; set; }
        public string RequestorID { get; set; }        
        public string Message { get; set; }

        public string RequestType { get; set; }

        public bool IsRead { get; set; }
    }
}
