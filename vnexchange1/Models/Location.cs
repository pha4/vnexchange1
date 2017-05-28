
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vnexchange1.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LocationRegion { get; set; }

        public int SortOrder { get; set; }
    }
}
