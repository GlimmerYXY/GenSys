using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspDotNetMVCBootstrapTable
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HttpAlarm",
                url: "alarm",
                defaults: new { controller = "Home", action = "RecvAlarm" }
            );

            routes.MapRoute(
                name: "HttpRegister",
                url: "register",
                defaults: new { controller = "Home", action = "RecvRegister" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
