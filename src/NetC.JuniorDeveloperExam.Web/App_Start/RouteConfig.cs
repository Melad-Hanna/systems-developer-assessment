using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BlogPost",
                url: "{controller}/{id}",
                defaults: new { controller = "Blog", action = "Index" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "HttpErrors", action = "NotFound" }
            );
        }
    }
}
