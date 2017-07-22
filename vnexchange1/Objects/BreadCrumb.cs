
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vnexchange1.Object
{
    public class BreadCrumb
    { 
        public string Value { get; set; }

        public string Text { get; set; }        
    }
}
