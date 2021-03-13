using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Grocery_Store.Models
{
    public class userData
    {
       

        
        [Key]
        public int userId { get; set; }  //primary key of userdata table

        [Required(ErrorMessage ="Email Address is Required")]
        [EmailAddress(ErrorMessage ="Enter a Email Address")]
        public string email { get; set; }  //property for user email

        [Required(ErrorMessage ="Password is Required")]
        [MinLength(7,ErrorMessage ="minlength for password is 7")]
        [DataType(DataType.Password)]
        public string password { get; set; }  //property for password of user





    }
}