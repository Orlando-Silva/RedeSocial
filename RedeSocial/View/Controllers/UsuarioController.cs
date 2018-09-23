#region --Using--
using Core.Entidades;
using Core.ViewModels;
using Helpers;
using Services;
using System;
using System.Web;
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

        [HttpGet]
        public ActionResult Perfil(int? usuarioID)
        {
            var usuario = UsuarioService.BuscarNaSessao(Session);

            if (usuario is Usuario && usuarioID is int)
            {
                var encryptedID = Seguranca.Encriptar(usuario.ID.ToString());
                var usuarioPerfil = UsuarioService.BuscarPorID(usuarioID.Value);
                return View(nameof(Perfil), new PerfilViewModel
                {
                    Usuario =  usuarioPerfil,
                    UsuarioEdicao = usuario,
                    PodeEditar = usuarioPerfil.ID == usuario.ID,
                    FU_pass = encryptedID
                });
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult Logout(Usuario _usuario)
        {
            return View(nameof(Login));
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
        public ActionResult AtualizarDados(PerfilViewModel perfilViewModel)
        {
            try
            {
                var usuarioID = int.Parse(Seguranca.Decriptar(perfilViewModel.FU_pass));
                var usuario = UsuarioService.BuscarPorID(usuarioID);

                usuario = ObjectHelper.MergeObjects(usuario, perfilViewModel.UsuarioEdicao);


                usuario = UsuarioService.Atualizar(usuario);
                UsuarioService.IniciarSessao(Session, usuario);
                return Perfil(usuario.ID);
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult AtualizarAvatar(HttpPostedFileBase FotoDePerfil)
        {
            try
            {
                var yeet = "If we got here, we should drink boys";
                return View();
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
                usuario.Senha = Seguranca.Encriptar(usuario.Senha);
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