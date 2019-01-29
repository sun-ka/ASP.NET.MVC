using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsAuthenticationDemo.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       // [Authorize(Roles ="Admins")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      // [Authorize(Roles = "Guests")]
      // [Authorize(Users ="Guest@Company.com","abc@company.com")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}