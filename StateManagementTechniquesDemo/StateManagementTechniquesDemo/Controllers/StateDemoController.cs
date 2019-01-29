using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagementTechniquesDemo.Controllers
{
    public class StateDemoController : Controller
    {
        // GET: StateDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StateManagementDemo()
        {
            ViewData["Ecode"] = 101;

            ViewBag.Ename = "Kameswara";

            TempData.Add("Country", "India");
            TempData.Keep();
            return View();

        }

        [HttpPost]
        public ActionResult StateManagementDemo(FormCollection col)
        {
            TempData.Keep();
            return View();

        }
    }
}