﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vnexchange1.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required, MaxLength(100)]
        public string ItemTitle { get; set; }

        [Required, MaxLength(1000)]
        public string ItemDescription { get; set; }
        [DataType(DataType.Currency)]
        public decimal ItemPrice { get; set; }

        [Required]
        public int ItemCategory { get; set; }

        [Required]
        public string ItemOwner { get; set; }

        public DateTime ItemDate
        {
            get; set;
        }



        public string ItemLocation { get; set; }

        public string ItemManufacturer { get; set; }

        public int ItemType { get; set; }

        public bool CanExchange { get; set; }

        public bool CanGiveAway { get; set; }

        public bool CanTrade { get; set; }

        public ICollection<ItemImage> Images { get; set; }

        public bool IsApproved { get; set; }

        public string ItemStatus { get; set; }

        public string ItemColor { get; set; }

        public string ItemSize { get; set; }

        public bool IsClosed { get; set; }

        public bool IsHide { get; set; }
        
    }
}
