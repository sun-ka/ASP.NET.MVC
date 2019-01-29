using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronglyTypedModelViewsDemo.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
    public class Products
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }

        public double Cost { get; set; }
        public double Tax { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}