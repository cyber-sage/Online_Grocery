using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class Category
    {
        [Key]
        public int categoryId{ get; set; }

        public string categoryName { get; set; }








    }
}