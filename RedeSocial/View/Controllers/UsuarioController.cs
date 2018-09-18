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
        public ActionResult Home(Usuario usuario)
        {
            if (UsuarioLogic.EstaLogado(Session, usuario))
            {
                var HomeViewModel = new HomeViewModel
                {
                    Usuario = usuario
                };
                return View(HomeViewModel);
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult Entrar() => View();

        public ActionResult Novo() => View();

        public ActionResult Login(LoginViewModel _usuario) => View();

        public ActionResult Logout(Usuario _usuario)
        {
            return View(nameof(Login));
        }

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
                var HomeViewModel = new HomeViewModel
                {
                    Usuario = UsuarioLogic.Login(Session, _usuario)
                };
                return View(nameof(Home), HomeViewModel);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(nameof(Login), _usuario);
            }
        }


    }
}