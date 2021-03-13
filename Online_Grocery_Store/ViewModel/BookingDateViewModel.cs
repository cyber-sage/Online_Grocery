using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Grocery_Store.Models;

namespace Online_Grocery_Store.ViewModel
{
    public class BookingDateViewModel
    {

        public Booking bookingViewModel { get; set; } 

        public List<time> timeViewModel { get; set; }
        public userData user { get; set; }




    }
}