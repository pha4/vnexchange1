
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class ItemType
    {
        [Key]
        public int ItemTypeId { get; set; }        
        [Required]
        public string ItemTypeDescription { get; set; }        
    }
}
