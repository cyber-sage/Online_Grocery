using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Online_Grocery_Store.Models
{
    public class groceryDbContext:DbContext //context class of the project 
    {
        public DbSet<BookedItems> bookedItems { get; set;} 

        public DbSet<sort> sorts{ get; set; }

        public DbSet<Booking> bookings { get; set; }  //property for previous booking table

        public DbSet<Cart> carts { get; set; } //property for cart table 

        public DbSet<Product> products  { get; set; }  //property for product details table

        public DbSet<time> times { get; set; }  


        public DbSet<userData> userDatas { get; set; }  //property for user data table 

        public DbSet<Category> categories { get; set; }

        public DbSet<Test> tests { get; set; }

        public DbSet<NameTest> nameTests { get; set; }

        public DbSet<EmailTest> emailTests { get; set; }








    }
}