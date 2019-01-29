using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithHandleErrorAttributeDemo
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string controllerName = "Hey! Your controller name is :  " + (string)filterContext.RouteData.Values["controller"];
            string actionName = "Hey Again! Your action name is : " + (string)filterContext.RouteData.Values["action"];

            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            //Do Logging

            ViewResult result = new ViewResult();
            result.ViewName = this.View;//"AnotherView.cshtml";
            result.MasterName = this.Master;
            result.ViewData = new ViewDataDictionary<HandleErrorInfo>(model);
            result.TempData = filterContext.Controller.TempData;
            filterContext.Result = result;

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}