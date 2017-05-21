
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class ItemImage
    {
        [Key]
        public int ItemImageId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string ImagePath { get; set; }     
        
        public bool IsMainImage { get; set; }
    }
}
