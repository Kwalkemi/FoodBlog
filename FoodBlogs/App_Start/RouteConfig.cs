using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodBlogs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Submit",
                url: "Home/Comments/{astrPostId}/{astrComment}/{astrEmail}",
                new
                {
                    controller = "Home",
                    action = "Comment",
                    astrPostId = UrlParameter.Optional,
                    astrComment = UrlParameter.Optional,
                    astrEmail = UrlParameter.Optional
                });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
