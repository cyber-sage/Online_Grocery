using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }  //primary key of booking table


        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }



        [Required(ErrorMessage ="Address is Required")]
 
        public string Address { get; set; }
        public int userId { get; set; }

        public double AmountPaid { get; set; }

        public DateTime BookingDate { get; set; }

        [ForeignKey("time")]
        public int timeID { get; set; }

        public virtual time time{ get; set; }

        public string Status { get; set; }

        public DateTime? DeliveredDate { get; set; }




    }
}