
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vnexchange1.Object
{
    public class CarouselHighlightItem
    {
        public int ItemID { get; set; }

        public string ItemTitle { get; set; }

        public string ItemStatus { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal ItemPrice { get; set; }

        public string ItemOwner { get; set; }

        public string ItemOwnerID { get; set; }

        public string ItemLocation { get; set; }

        public string ItemImage { get; set; }
    }
}
