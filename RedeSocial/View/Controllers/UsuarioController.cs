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

        #region --Redirect Actions--
        public ActionResult Entrar() => View();

        public ActionResult Novo() => View();

        public ActionResult Login(LoginViewModel _usuario) => View();
        #endregion

        #region --Post Actions--
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
                return Home();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(nameof(Login), _usuario);
            }
        }
        #endregion

        public ActionResult Home()
        {
            if (UsuarioLogic.EstaLogado(Session))
            {
                var HomeViewModel = new HomeViewModel
                {
                    Usuario = UsuarioLogic.BuscarDaSession(Session)
                };
                return View(nameof(Home),HomeViewModel);
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult Perfil(int? usuarioID)
        {
            if (UsuarioLogic.EstaLogado(Session) && usuarioID is int)
            {
                var usuarioPerfil = UsuarioLogic.BuscarPorId(usuarioID.Value);
                var usuarioLogado = UsuarioLogic.BuscarDaSession(Session);
                var PerfilViewModel = new PerfilViewModel
                {
                    Usuario = usuarioPerfil,
                    PodeEditar = usuarioPerfil.ID == usuarioLogado.ID
                };
                return View(nameof(Perfil), PerfilViewModel);
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult Logout(Usuario _usuario)
        {
            return View(nameof(Login)); //  TODO: Fazer logout.
        }

    }
}