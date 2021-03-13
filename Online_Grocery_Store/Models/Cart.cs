using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class Cart
    {
        [Key]
        public int cartId { get; set; }

        public int productId { get; set; }

        public string productName { get; set; }
        public int Quantity { get; set; }


        public double price { get; set; }

        public double totalPrice { get; set; }





    }
}