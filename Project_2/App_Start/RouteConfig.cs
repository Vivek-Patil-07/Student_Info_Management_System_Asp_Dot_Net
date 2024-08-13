using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_2
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

        //    routes.MapRoute(
        //        name: "Login",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
        //    );

        //    routes.MapRoute(
        //       name: "Register",
        //      url: "{controller}/{action}/{id}",
        //       defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
        //  );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Student",
                url: "Student/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
