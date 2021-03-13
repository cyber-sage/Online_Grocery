using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class BookedItems
    {
        [Key]

        public int id { get; set; }

        public int productId { get; set; }

        public string  productName{ get; set; }

        public double Price { get; set; }


        public int Quantity { get; set; }

        public double totalPrice { get; set; }

        [ForeignKey("Booking")]
        public int bookingId { get; set; }

        public Booking Booking { get; set; }





    }
}