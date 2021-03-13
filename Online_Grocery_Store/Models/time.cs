using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class time
    {
        [Key]
        public int timeid { get; set; }

        public string availableTime{ get; set; }




    }
}