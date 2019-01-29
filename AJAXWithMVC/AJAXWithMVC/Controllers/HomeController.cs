using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAXWithMVC.Controllers
{
    public class HomeController : Controller
    {

        public string GetCurrentTime()
        {

            System.Threading.Thread.Sleep(5000);
            return DateTime.Now.ToLongTimeString();
        }

        public string ShowMessage(string FirstName)
        {
            return "Welcome Back  " + FirstName;
        }

        public ActionResult Index()
        {
            return View();
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