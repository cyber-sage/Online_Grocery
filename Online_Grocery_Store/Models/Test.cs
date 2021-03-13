using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Grocery_Store.Models
{
    public class Test
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }


    }
}