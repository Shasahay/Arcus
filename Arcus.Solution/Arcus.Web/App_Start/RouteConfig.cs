using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Arcus.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
            routes.MapRoute(
                name:"Name",
                url:"{categoryName}", // {controller}/{categoryName}
                defaults:new { controller = "Home", action = "Category", id = "" },
                constraints:   new RouteValueDictionary { { "categoryName", "^[a-zA-Z0-9\\-\\s]+$" } }
                );

            routes.MapRoute(
               name: "Default1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
           
        }
    }
}
