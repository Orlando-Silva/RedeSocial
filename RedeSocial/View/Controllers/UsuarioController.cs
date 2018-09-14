#region --Using--
using System.Web.Mvc;
using View.ViewModels;
#endregion

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Home(int usuarioID)
        {
            return View();
        }

        public ActionResult Novo() => View();
        
        public ActionResult Adicionar(NovoUsuarioViewModel usuario)
        {
            return View(nameof(Home));
        }
    }
}