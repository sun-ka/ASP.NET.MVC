using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using UnderstandingBindingTechniquesDemo.Models;

namespace UnderstandingBindingTechniquesDemo
{
    public class CustomCustomerBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            Customer customer;
            if (bindingContext.Model == null)
            {
                customer = new Customer();
                customer.PresentAddress = new AddressSummary();
                customer.PermanentAddress = new AddressSummary();
            }
            else
            {
                //if UpdateModel(customer) or TryUpdateModel(customer) is used.
                customer = (Customer)bindingContext.Model;
            }
            customer.CustomerID = GetValue<int>(bindingContext, "CustomerID");
            customer.PresentAddress.Country = GetValue<string>(bindingContext, "pac");
            customer.PresentAddress.City = GetValue<string>(bindingContext, "pc");
            customer.PresentAddress.Street = GetValue<string>(bindingContext, "ps");

            customer.PermanentAddress.Country = GetValue<string>(bindingContext, "pmac");
            customer.PermanentAddress.City = GetValue<string>(bindingContext, "pmc");
            customer.PermanentAddress.Street = GetValue<string>(bindingContext, "pms");
            return customer;
        }

        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {

            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
            bindingContext.ModelState.SetModelValue(key, valueResult);
            return (T)valueResult.ConvertTo(typeof(T));

        }
    }
}