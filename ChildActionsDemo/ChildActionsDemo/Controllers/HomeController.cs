using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildActionsDemo.Controllers
{
    public class HomeController : Controller
    {

        [ChildActionOnly]
        public ActionResult GetTime()
        {
            return PartialView(DateTime.Now);
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