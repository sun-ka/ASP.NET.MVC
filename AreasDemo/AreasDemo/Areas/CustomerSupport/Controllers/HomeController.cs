using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasDemo.Areas.CustomerSupport.Controllers
{
    public class HomeController : Controller
    {
        // GET: CustomerSupport/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}