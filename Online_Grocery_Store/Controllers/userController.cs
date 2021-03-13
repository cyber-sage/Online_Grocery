using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Grocery_Store.Models;

namespace Online_Grocery_Store.Controllers
{
    public class userController : Controller
    {
        // GET: user

        private groceryDbContext context = new groceryDbContext();  //private object of Dbcontext class
        
        public ActionResult Login()// Action for customer Login
        {
            var userdata = new userData();

            return View(userdata);
        }

        [HttpPost]
        public ActionResult Login(userData data) //Post action for customer Login
        {


            

            ViewBag.email = ""; //viewbag for email exist error
            ViewBag.password = ""; //viewbag for incorrect password

            var emailCheck = context.userDatas.SingleOrDefault(c=>c.email==data.email); //fetching user data from database
            if (emailCheck == null) //if block checking if user exists in the database
            {
                ViewBag.email = "User Does not Exists";

                return View(data);
            }
            else if (emailCheck.password != data.password) //else block checking if password is correct
            {
                ViewBag.password = "Password Does not Match";
                
                return View(data);
            }



            return RedirectToAction("dashboard","shopping", new { userId=emailCheck.userId}); //redirecting user to dashboard after successful login
        
        }

        public ActionResult SignUp() //Action for user Signup
        {

            var userdata = new userData();

            return View(userdata);
        }

        [HttpPost]
        public ActionResult SignUp(userData data)  //Post Action for user Signup
        {



            ViewBag.exist = ""; //viewbag for showing user already exists error

            var check = context.userDatas.SingleOrDefault(c=>c.email==data.email);

            if (!(check == null)) {
                ViewBag.exist = "user already exist";
                return View(data);
            
            }




            context.userDatas.Add(data);  //Saving user data in database
            context.SaveChanges();

            return RedirectToAction("dashboard", "shopping", new { userId =data.userId });  //redirecting user to dashboard
        }

        public ActionResult Logout()  //Action for logout button
        {


            return RedirectToAction("Login","user");
        }
    }
}