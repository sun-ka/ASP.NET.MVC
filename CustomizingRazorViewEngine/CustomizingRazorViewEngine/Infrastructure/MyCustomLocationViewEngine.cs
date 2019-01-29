using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomizingRazorViewEngine.Infrastructure
{
    public class MyCustomLocationViewEngine : RazorViewEngine
    {
        public MyCustomLocationViewEngine()
        {
            ViewLocationFormats = new string[]
              {"~/Views/{1}/{0}.cshtml", "~/Views/MyCustomShared/{0}.cshtml"};
        }
    }
}