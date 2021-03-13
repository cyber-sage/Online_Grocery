using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Grocery_Store.Models;

namespace Online_Grocery_Store.ViewModel
{
    public class productSearchViewModel
    {

        public List<Product> productView { get; set; }

        public Product productLabelView { get; set; }
        public int productID { get; set; }

        public List<Category> categoryView { get; set; }

        public Category cate { get; set; }

        public sort MyProperty { get; set; }

        public int userId { get; set; }

        public userData user { get; set; }

        public sort sortTypeView { get; set; }
        public List<sort> sortView { get; set; }

        public int quantity { get; set; }


    }
}