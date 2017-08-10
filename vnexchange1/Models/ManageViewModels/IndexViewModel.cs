using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using vnexchange1.PaginatedList;
using vnexchange1.ViewModels;

namespace vnexchange1.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public PaginatedList<Item> PostingItems { get; set; }

        public PaginatedList<Item> WaitingItems { get; set; }

        public PaginatedList<Item> ClosedItems { get; set; }

        public PaginatedList<Item> HiddenItems { get; set; }

        public PaginatedList<Item> InterestingItems { get; set; }

        public ItemMessageViewModel ItemMessages { get; set; }

        public int Waiting { get; set; }

        public int Ended { get; set; }
    }
}
