#region --Using--
using BusinessLogic;
using Core.Entidades;
using Core.ViewModels;
using Services;
using System;
using System.Web.Mvc;
#endregion

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        #region --Atributos--
        private readonly UsuarioService UsuarioService;
        #endregion

        #region --Construtor--
        public UsuarioController()
        {
            UsuarioService = new UsuarioService();
        }
        #endregion

        #region --HTTP GET--
        [HttpGet]
        public ActionResult Entrar() => View();

        [HttpGet]
        public ActionResult Novo() => View();

        [HttpGet]
        public ActionResult Login(LoginViewModel _usuario) => View();

        [HttpGet]
        public ActionResult Home()
        {
            var usuario = UsuarioService.BuscarNaSessao(Session);
            if (usuario is Usuario)
            {         
                return View(nameof(Home), new HomeViewModel
                {
                    Usuario = usuario
                });
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult Perfil(int? usuarioID)
        {
            var usuario = UsuarioService.BuscarNaSessao(Session);
            if (usuario is Usuario && usuarioID is int)
            {
                var usuarioPerfil = UsuarioLogic.BuscarPorId(usuarioID.Value);
                return View(nameof(Perfil), new PerfilViewModel
                {
                    Usuario = usuarioPerfil,
                    PodeEditar = usuarioPerfil.ID == usuario.ID
                });
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
        #endregion

        #region --HTTP POST--
        [HttpPost]
        public ActionResult Adicionar(Usuario usuario)
        {
            try
            {
                usuario = UsuarioService.Adicionar(usuario);
                UsuarioService.IniciarSessao(Session, usuario);
                return View(nameof(Home));
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            try
            {
                UsuarioService.IniciarSessao(Session, usuario);          
                return Home();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(nameof(Login), usuario);
            }
        }
        #endregion
    }
}