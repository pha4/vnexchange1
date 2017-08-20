using System.Collections.Generic;
using vnexchange1.Models;

namespace vnexchange1.ViewModels
{
    public class ItemMessageViewModel
    {
        public List<ItemRequest> ItemRequests { get; set; }
        public List<Item> Items { get; set; }
        public List<string> Emails { get; set; }
    }
}
