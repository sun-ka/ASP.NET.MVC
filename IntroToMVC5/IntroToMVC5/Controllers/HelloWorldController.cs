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
            ViewBag.Greetings = "Hello World From MVC 5.0";

            ViewBag.Name = "Kameswara Sarma Uppuluri";
            ViewBag.Country = "India";

            Authors a = new Authors();
            a.AuthorName = "UK Sarma";
            a.AuthorCountry = "India";




            return View(a);
        }

        public ActionResult QueryStringIndex(string Message="Hello World From MVC 5.0")
        {
            ViewBag.Greetings = Message;
            return View();
        }

        public ActionResult GotoURL(string url="http://www.google.com")
        {
            return Redirect(url);
        }
    }
}