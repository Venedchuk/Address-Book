using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Address_Book
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string defaultUrl = "localhost";
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            string urls = ConfigurationManager.AppSettings["Urls"] ?? defaultUrl;
            foreach (string url in urls.Split(';'))
            {
                routes.MapRoute(
                    $"Web {url}",
                    url: "{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            }
        }
    }
}
