using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Code_Box
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "CSharp",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "CSharp", action = "CSharpTutorial", id = UrlParameter.Optional }
           );

           // routes.MapRoute(
           //    name: "Admin",
           //    url: "{controller}/{action}/{id}",
           //    defaults: new { controller = "PostBlog", action = "PostBlog", id = UrlParameter.Optional }
           //);
        }
    }
}
