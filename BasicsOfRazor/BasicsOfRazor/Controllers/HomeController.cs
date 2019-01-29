using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicsOfRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExceptionHandlingDemo()
        {
            return View();
        }

        public ActionResult DictionaryDemo()
        {
            return View();
        }
        public ActionResult SwitchDemo()
        {
            return View();
        }
        public ActionResult LoopingStatementsDemo()
        {
            return View();
        }
        public ActionResult WorkingWithForms()
        {
            return View();
        }
        public ActionResult IfDemo()
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