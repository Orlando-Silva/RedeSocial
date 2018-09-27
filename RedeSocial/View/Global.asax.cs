#region -- Using--
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using View.App_Start;
#endregion

namespace View
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
