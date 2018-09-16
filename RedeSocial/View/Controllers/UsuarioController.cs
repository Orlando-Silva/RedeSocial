#region --Using--
using BusinessLogic;
using Core.Entidades;
using Core.ViewModels;
using System;
using System.Web.Mvc;
#endregion

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Home(Usuario usuario) => UsuarioLogic.EstaLogado(Session,usuario) ? View() : View(nameof(Login));       

        public ActionResult Entrar() => View();

        public ActionResult Novo() => View();

        public ActionResult Login(LoginViewModel _usuario) => View();    

        [HttpPost]
        public ActionResult Adicionar(NovoUsuarioViewModel _usuario)
        {
            UsuarioLogic.Adicionar(Session, _usuario);
            return View(nameof(Home));
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel _usuario)
        {
            try
            {
                UsuarioLogic.Login(Session, _usuario);
                return View(nameof(Home));
            }
            catch(Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(nameof(Login),_usuario);
            }
        }


    }
}