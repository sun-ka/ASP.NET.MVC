using StronglyTypedModelViewsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StronglyTypedModelViewsDemo.Controllers
{
    public class ProductsController : Controller
    {
            static Products prod = new Products();

        static List<Products> _Products = new List<Products>
        {
            new Products {
                ProductID = 1,
                ProductName = "Intel i7",
                Quantity=100,
                UnitsInStock=50,
                Discontinued = false
            },
            new Products {
                ProductID = 2,
                ProductName = "Intel I5",
                Quantity=100,
                UnitsInStock=70,
                Discontinued = false
            },
               new Products {
                ProductID = 3,
                ProductName = "Intel I3",
                Quantity=100,
                UnitsInStock=80,
                Discontinued = false
            },
                  new Products {
                ProductID = 4,
                ProductName = "Intel QuadCore",
                Quantity=100,
                UnitsInStock=40,
                Discontinued = false
            },

        };

        public ProductsController()
        {
            prod.ProductID = 1;
            prod.ProductName = "NoteBook";
            prod.Quantity = 100;
            prod.UnitsInStock = 78;
            prod.Discontinued = true;
            prod.CategoryID = 3;
            prod.Cost = 5000;
            prod.LaunchDate = new DateTime(2016, 04, 01);
        }

        public ActionResult DisplayProductInfo()
        {
            return View(prod);
        }

        public ActionResult EditProductInfo()
        {
            return View(prod);
        }

        public ActionResult DisplayAllProducts()
        {
            var model = from p in _Products
                        where p.UnitsInStock >= 60
                        select p;

            //return View(_Products);
            return View(model);
        }
        // GET: Products
        public ActionResult Index()
        {
            
            prod.ProductID = 1;
            prod.ProductName = "NoteBook";
            prod.Quantity = 100;
            prod.UnitsInStock = 78;
            prod.Discontinued = true;
            prod.CategoryID = 3;
            prod.Cost = 5000;
            prod.LaunchDate = new DateTime(2016, 04, 01);

            List<Categories> categories = new List<Categories>();
            categories.Add(new Categories() { CategoryID = 1, CategoryName = "Fashion" });
            categories.Add(new Categories() { CategoryID = 2, CategoryName = "Electronics" });
            categories.Add(new Categories() { CategoryID = 3, CategoryName = "Computers" });
            categories.Add(new Categories() { CategoryID = 4, CategoryName = "Sports" });

            SelectList sl = new SelectList(categories, "CategoryID", "CategoryName", prod.CategoryID);
            TempData["CategoriesList"] = sl;
            TempData.Keep();

            return View(prod);


        }
        [HttpPost]
        public ActionResult Index(Products prod)
        {
            ModelState.Clear();
            prod.Tax = prod.Cost * 10 / 100;
            TempData.Keep();
            return View(prod);
        }


    }
}