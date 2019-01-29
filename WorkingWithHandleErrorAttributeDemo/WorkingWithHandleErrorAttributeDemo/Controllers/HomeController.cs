using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithHandleErrorAttributeDemo.Controllers
{
  //  [HandleError]
    public class HomeController : Controller
    {
       [HandleError]
        public ActionResult Index()
        {
            int a, b, c;
            a = 10;
            b = 2;
            c = a / b;
            return Content(c.ToString());

            //return View();
        }
        //[HandleError]
       // [HandleError(ExceptionType = typeof(System.DivideByZeroException), View = "Contact")]
       [CustomHandleError]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            int a, b, c;
            a = 10;
            b = 0;
            c = a / b;
            return Content(c.ToString());
            //return View();
        }
       // [HandleError]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            int a, b, c;
            a = 10;
            b = 0;
            c = a / b;
            return Content(c.ToString());
           // return View();
        }
    }
}