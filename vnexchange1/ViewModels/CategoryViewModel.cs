using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vnexchange1.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
        public int CategoryOrder { get; set; }        
        public string CategoryImage { get; set; }

        public string CategoryIcon { get; set; }

        public int CategoryCount { get; set; }
    }
}
