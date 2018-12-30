using IntroToMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroToMVC5.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            ViewBag.Greetings = "Hello From HelloWorldController";
            ViewBag.Name = "Lena";
            ViewBag.Country = "Ukraine";
            Authors a = new Authors();
            a.AuthorName = "Lena";
            a.AuthorCountry="Ukraine";

            return View(a);
        }

        public ActionResult QueryStringActions(string Message = "Default message in QueryStringActions method")
        { 
            ViewBag.Greetings = Message;
            return View();
        }

        public ActionResult GoToURL(string url = "http://www.google.com")
        {
            return Redirect(url);
        }
    }
}