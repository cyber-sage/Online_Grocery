using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class Product
    {
        //class for product details table

        [Key]
        public int productId { get; set; }  //primary key of product table

        [Required]
        public string productName { get; set; }  //product name of the product 


        [ForeignKey("Category")]
        public int cateID { get; set; }  //foreign key of category table

        public virtual Category Category{ get; set; }

        public string Description { get; set; } //description about the product


        
        public string ImagePath { get; set; } //property for image of the project

        public double Price { get; set; } //price of item

        public int Quantity { get; set; }  //property for qunatity of item in table









    }
}