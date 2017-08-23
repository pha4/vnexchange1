using System.Collections.Generic;
using vnexchange1.Models;

namespace vnexchange1.ViewModels
{
    public class ItemMessageViewModel
    {
        public int RequestID { get; set; }

        public string ItemID { get; set; }
        public string RequestorID { get; set; }
        public string Message { get; set; }

        public string RequestType { get; set; }

        public bool IsRead { get; set; }

        public Item Item { get; set; }
        public string Email { get; set; }
    }
}
