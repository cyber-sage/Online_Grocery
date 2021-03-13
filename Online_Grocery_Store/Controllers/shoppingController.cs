using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Grocery_Store.Models;
using Online_Grocery_Store.ViewModel;
using PagedList;
using PagedList.Mvc;

namespace Online_Grocery_Store.Controllers
{
    public class shoppingController : Controller
    {
        private groceryDbContext context = new groceryDbContext();  //private object of Dbcontext
        // GET: shopping
        public ActionResult dashboard(int userId)  //Action for user dashboard
        {
            ViewBag.orderCount = "";
            ViewBag.userID = userId;
            var myorders = context.bookings.Where(c => c.userId == userId).ToList(); //fetching details of all previous user orders

            if (myorders.Count() == 0) 
            {
                ViewBag.orderCount = "noOrder"; //Viewbag to show message when there is no previous booking

            }


            return View(myorders); 
        }

        public ActionResult Billing(int bookId) //action to show complete biiling details of given customer order
        
        {
            var total = 0.0;
            ViewBag.total = 0;

            var billDetails = context.bookedItems.Where(c => c.bookingId == bookId).ToList();
            foreach (var item in billDetails) {

                total += item.Price * item.Quantity;
            }
            ViewBag.total = total;

            return View(billDetails);
        }

        public ActionResult Order(int userId)    //Action to show all the available products in the database
        {
            ViewBag.userID = userId;  //Viewbag to transfer userid to view

            var productviewmodel = new productSearchViewModel();  //object of productSearch Viewmodel
            
            productviewmodel.userId = userId;


            



            productviewmodel.productView = context.products.ToList();  //List of all the products in the database
            productviewmodel.categoryView = context.categories.ToList();  //List of all the categories in the database for dropdownlist 
            productviewmodel.sortView = context.sorts.ToList();   //List of all the type of sorting available
            

            return View(productviewmodel);

        }

        [HttpPost]
        public ActionResult Order(productSearchViewModel data)   //Post Action for data obtained from category dropdown form in view
        {
            var category = data.cate.categoryId;
            var productViewModel = new productSearchViewModel();

            var sortCondition = data.sortTypeView.sortType;

            var userID = data.userId;

            if (!(Convert.ToDouble(category) == double.NaN && sortCondition == null)) //block of code when category and sorting both are selected
            {
                productViewModel.productView = context.products.Where(c => c.cateID == category).OrderBy(c => c.Price).ToList();
                productViewModel.categoryView = context.categories.ToList();
                productViewModel.sortView = context.sorts.ToList();
                ViewBag.userID = userID;  //
                productViewModel.userId = userID;

            



                return View(productViewModel);

            }

            else if ((Convert.ToDouble(category) != double.NaN && sortCondition == null)==true) //block of code when only category is selected
            {


                productViewModel.productView = context.products.Where(c => c.cateID == category).ToList();
                productViewModel.categoryView = context.categories.ToList();
                productViewModel.sortView = context.sorts.ToList();
                ViewBag.userID = userID;
                productViewModel.userId = userID;





                return View(productViewModel);




            }
            else if ((sortCondition != null && Convert.ToDouble(category) == double.NaN)==true) //block of code  when only  sorting is selected 
            {


                productViewModel.productView = context.products.OrderBy(c => c.Price).ToList();
                productViewModel.categoryView = context.categories.ToList();
                productViewModel.sortView = context.sorts.ToList();
                ViewBag.userID = userID;
                productViewModel.userId = userID;





                return View(productViewModel);




            }







            RedirectToAction("Order", "shopping", new { userId = userID });
            return View();


        }

        public ActionResult cartAdd(int UserId)  //Action for adding items in cart
        {



            ViewBag.cartItemCount = "";

            ViewBag.UserID = UserId;
            ViewBag.grandTotal = 0.0; //viewbag for grandtotal


          

            var cartTablePre = context.carts.ToList(); 

            if (cartTablePre.Count() == 0)
            {

                ViewBag.cartItemCount = "Zero";

            }
          

            foreach (var item in cartTablePre) //foreach loop to calculate total price of items in cart
            {

                ViewBag.grandTotal += item.totalPrice;

            }




            return View(cartTablePre);
        }



        [HttpPost]
        public ActionResult cartAdd(productSearchViewModel data)  //Action to add item from order cshtml to cart
        {

            ViewBag.cartItemCount = "";

            ViewBag.UserID = data.userId;
            ViewBag.grandTotal = 0.0;


            var cartItems = new Cart();

            var cartTablePre = context.carts.ToList();

              


            var productData = context.products.Find(data.productID);
            cartItems.productId = productData.productId;
            cartItems.productName = productData.productName;
            cartItems.price = productData.Price;
             cartItems.Quantity = data.quantity;
            cartItems.totalPrice = cartItems.price* cartItems.Quantity;

            context.carts.Add(cartItems);
            context.SaveChanges();

            var cartTablePost = context.carts.ToList();

        foreach (var item in cartTablePost) {

                    ViewBag.grandTotal += item.totalPrice;

            }


            




            return View(cartTablePost);
        }



        public ActionResult deleteItem(int cartId,int userId)  //Action to remove items from cart adding payemnt
        {

            var delItem = context.carts.Find(cartId);
            context.carts.Remove(delItem);
            context.SaveChanges();




            return RedirectToAction("cartAdd","shopping",new { UserId=userId});
        }



        public ActionResult buy( int userID,double total) //Action to get the details of the customers
        
        {

            ViewBag.email = context.userDatas.Find(userID).email;

            ViewBag.userId = userID;
            ViewBag.Total=total;

           
            var bookingdateviewmodel = new BookingDateViewModel();
           
           

            bookingdateviewmodel.timeViewModel = context.times.ToList();


            return View(bookingdateviewmodel);
        
        }

        [HttpPost]
        public ActionResult buy(BookingDateViewModel data) //Action to complete payment and save billing details in the database tables 
        {


           


            data.bookingViewModel.BookingDate = DateTime.Now; //Saving timing of payment 
            data.bookingViewModel.Status = "Not shipped"; //initial delivery status 
            


            context.bookings.Add(data.bookingViewModel);  //adding payment details in database

            context.SaveChanges();
            var bookid = data.bookingViewModel.BookingId;


            var bookedItems = new BookedItems();


            var cartItem = context.carts.ToList();
            foreach (var item in cartItem) {

                var quantitysub = context.products.Find(item.productId).Quantity-item.Quantity;
                context.products.Find(item.productId).Quantity = quantitysub;


                bookedItems.productId = item.productId;
                bookedItems.productName = item.productName;
                bookedItems.Price = item.price;
                bookedItems.Quantity = item.Quantity;
                bookedItems.totalPrice = item.totalPrice;
                bookedItems.bookingId = bookid;
                context.bookedItems.Add(bookedItems);
                context.SaveChanges();
            
            
            
            }

            context.carts.RemoveRange(context.carts.ToList());

            context.SaveChanges();




            return RedirectToAction("dashboard","shopping",new { userId=data.bookingViewModel.userId}); //redirecting to customer database

        
        }

        public ActionResult Huihui() {

            

            return View(context.Database.SqlQuery<Test>("samidare").ToList());
        }




    }
}