#region --Using--
using BusinessLogic;
using Core.ViewModels;
using System.Web.Mvc;
#endregion

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Novo() => View();
        
        public ActionResult Adicionar(NovoUsuarioViewModel _usuario)
        {
            UsuarioLogic.Adicionar(_usuario);
            return View(nameof(Home));
        }
    }
}