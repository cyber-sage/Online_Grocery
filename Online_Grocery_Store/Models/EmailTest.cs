using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Grocery_Store.Models
{
    public class EmailTest
    {

        [Key]
        public int id { get; set; }

        public string Email { get; set; }

        public NameTest NameTest { get; set; }

        public int NameID { get; set; }

    }
}