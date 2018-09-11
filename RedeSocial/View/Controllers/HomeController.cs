#region --Using--
using System.Web.Mvc;
#endregion

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();      
    }
}