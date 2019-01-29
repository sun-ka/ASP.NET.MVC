using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnderstandingBindingTechniquesDemo.Models
{
    public class Person
    {
        public string PersonID
        { get; set; }
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public AddressSummary Address
        { get; set; }
        public string Photo
        { get; set; }
    }


    public class AddressSummary
    {
        [System.ComponentModel.DataAnnotations.MinLength(3)]

        public string Country
        { get; set; }
        public string Street
        { get; set; }
        public string City
        { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public AddressSummary PresentAddress { get; set; }
        public AddressSummary PermanentAddress { get; set; }
    }
}