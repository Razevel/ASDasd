using System.Web.Mvc;
using System.Web.Routing;

namespace TestYST_Rodionov
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                null,
                "Catalog",
                new { controller = "Catalog", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "Catalog/Filter",
                new { controller = "Catalog", action = "Filter", page = 1 }
            );

            routes.MapRoute(
                null,
                "Catalog/Page",
                new { controller = "Catalog", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "Catalog/Page{page}",
                new { controller = "Catalog", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
