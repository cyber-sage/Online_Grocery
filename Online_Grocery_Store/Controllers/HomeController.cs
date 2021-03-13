using Online_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Online_Grocery_Store.Controllers
{

   
    public class HomeController : Controller
    {
        private groceryDbContext context = new groceryDbContext();
        public ActionResult Index1()
        {
            var test = new EmailTest();

            return View(test);
        }
        [HttpPost]
        public ActionResult Index1(EmailTest testData)
        {
            context.emailTests.Add(testData);
            context.SaveChanges();

            return Content("Its okay");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}