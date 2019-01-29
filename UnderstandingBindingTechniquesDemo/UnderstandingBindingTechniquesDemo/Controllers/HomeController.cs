using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnderstandingBindingTechniquesDemo.Models;

namespace UnderstandingBindingTechniquesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, IEnumerable<string> categories)
        {
            string str = Request.Form.ToString();
            str += "<br/>Name: " + name + "<br/>categories: ";
            foreach (var s in categories)
            {
                str += s + " ";
            }
            return Content(str);
        }


        //public ActionResult GetPersonDetails(Person person, HttpPostedFileBase photo)
        //public ActionResult GetPersonDetails([Bind(Exclude = "PersonID")]Person person, HttpPostedFileBase photo)

        public ActionResult GetPersonDetails([Bind(Include = "Address")]Person person, HttpPostedFileBase photo)
        {
            string str = person.PersonID + ", " + person.FirstName + " , " + person.LastName + "<br>" + person.Address.Country + ", " + person.Address.City + " , " + person.Address.Street;
            if (photo != null)
            {
                string vpath = "~/Content/Photos/" + photo.FileName;
                string ppath = Server.MapPath(vpath);
                photo.SaveAs(ppath);
            }
            return Content(str);

        }
        //[HttpPost]
        // public ActionResult GetAddressDetails(AddressSummary present, AddressSummary permanent)
        // public ActionResult GetAddressDetails(AddressSummary b, AddressSummary permanent)

        //public ActionResult GetAddressDetails([Bind(Prefix = "Present")]AddressSummary b, AddressSummary permanent)
        //{
        //    string str = "";
        //    //str = present.Country + " , " + present.Street + ", " + present.City + "<br>";

        //    str = b.Country + " , " + b.Street + ", " + b.City + "<br>";

        //    str += permanent.Country + " , " + permanent.Street + ", " + permanent.City + "<br>";
        //    return Content(str);
        //}

        [HttpPost]
        public ActionResult GetAddressDetails(FormCollection fc)
        {

            AddressSummary present = new AddressSummary();
            AddressSummary permanent = new AddressSummary();
            string str = "";


            UpdateModel(present, "present"); //Will throw exception if validation fails

            bool result = TryUpdateModel(permanent, "permanent"); //Return false when validation fails.

            str += "present: " + present.Country + " , " + present.Street + ", " + present.City + "<br>";
            str += "permanent: " + permanent.Country + " , " + permanent.Street + ", " + permanent.City + "<br>";
            return Content(str + " " + " " + result);
        }

        [HttpPost]
        //public ActionResult GetCustomerDetails(Customer customer)
        public ActionResult GetCustomerDetails([ModelBinder(typeof(CustomCustomerBinder))]Customer customer)
        {


            string str = "Customer ID:" + customer.CustomerID + "<br>";
            str += "Present : " + customer.PresentAddress.Country + customer.PresentAddress.City + ", " + customer.PresentAddress.Street + "<br>";
            str += "Permanent : " + customer.PermanentAddress.Country + ", " + customer.PermanentAddress.Street + " , " + customer.PermanentAddress.City + "<br>";
            return Content(Request.Form + "<hr/>" + str);

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