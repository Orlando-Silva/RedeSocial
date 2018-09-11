#region --Using--
using System.Web.Mvc;
using System.Web.Routing;
using View.Controllers;
#endregion

namespace View
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = nameof(HomeController).Replace("Controller", string.Empty), action = nameof(HomeController.Index), id = UrlParameter.Optional }
            );
        }
    }
}
