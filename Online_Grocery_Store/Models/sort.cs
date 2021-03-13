using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Grocery_Store.Models
{
    public class sort
    {
        [Key]
        public int Id { get; set; }
        public string sortType { get; set; }


    }
}