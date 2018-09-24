#region --Using--
using Core.Entidades;
using Core.ViewModels;
using Helpers;
using Services;
using System;
using System.Web;
using System.Web.Mvc;
using View.ViewModels;
#endregion

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        #region --Atributos--
        private readonly UsuarioService UsuarioService;
        private readonly FotoDePerfilService FotoDePerfilService;
        private readonly PostagemService PostagemService;
        private readonly AmizadeService AmizadeService;
        private Usuario Usuario
        {
            get
            {
                return UsuarioService.BuscarNaSessao(Session);
            }
        }
        #endregion

        #region --Construtor--
        public UsuarioController()
        {
            UsuarioService = new UsuarioService();
            FotoDePerfilService = new FotoDePerfilService();
            PostagemService = new PostagemService();
            AmizadeService = new AmizadeService();
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
            try
            {
                if (Usuario != null)
                {
                    var postagens = PostagemService.BuscarPostagensFeed(Usuario.ID);
                    return View(nameof(Home), new HomeViewModel(Usuario, postagens));
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult BuscarUsuarios(string nome)
        {
            try
            {
                if (Usuario != null)
                {
                    var usuariosEncontrados = UsuarioService.BuscarPorNome(nome);
                    var amizades = AmizadeService.Buscar(Usuario.ID, Core.Enums.Status.Ativo);
                    return View(new BuscarUsuariosViewModel(Usuario, usuariosEncontrados, amizades));
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult Perfil(int? usuarioID)
        {
            try
            {
                if (Usuario != null)
                {

                    if (!(usuarioID is int) || usuarioID.Value <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    var IDEncriptado = Seguranca.Encriptar(Usuario.ID.ToString());
                    var perfil = UsuarioService.BuscarPorID(usuarioID.Value);
                    var postagens = PostagemService.BuscarPostagensPerfil(perfil.ID);
                    var amigos = AmizadeService.BuscarAmigos(perfil.ID, Core.Enums.Status.Ativo);

                    return View(nameof(Perfil), new PerfilViewModel(usuario: perfil, postagens: postagens, amigos: amigos, usuarioEdicao: Usuario, podeEditar: perfil.ID == Usuario.ID, passeEncriptado: IDEncriptado));
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult AdicionarAmigo(int convidadoID)
        {
            try
            {
                if (Usuario != null)
                {
                    var convidado = UsuarioService.BuscarPorID(convidadoID);

                    if (convidado != null)
                    {
                        var amizade = AmizadeService.Adicionar(Usuario.ID, convidado.ID);
                    }

                    return Home();
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult DesfazerAmizade(int convidadoID)
        {
            try
            {
                if (Usuario != null)
                {
                    var usuarioConvidado = UsuarioService.BuscarPorID(convidadoID);
                    var amizade = AmizadeService.Buscar(Usuario.ID, usuarioConvidado.ID);

                    AmizadeService.Atualizar(amizade.ID, Core.Enums.Status.Inativo);
                    return Home();
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
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
                return Home();
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
                var usuarioID = int.Parse(Seguranca.Decriptar(perfilViewModel.PasseEncriptado));
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
        public ActionResult AtualizarAvatar(HttpPostedFileBase FotoDePerfil, PerfilViewModel perfilViewModel)
        {
            try
            {
                var usuarioID = int.Parse(Seguranca.Decriptar(perfilViewModel.PasseEncriptado));
                string diretorio = Server.MapPath("~/Images/FotosDePerfil");
                // TODO: Crop.
                FotoDePerfilService.Adicionar(FotoDePerfil, usuarioID, diretorio);
                var usuario = UsuarioService.BuscarPorID(usuarioID);
                UsuarioService.IniciarSessao(Session, usuario);
                return Perfil(usuarioID);
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

        [HttpPost]
        public ActionResult Postar(HomeViewModel homeViewModel)
        {
            try
            {
                var usuario = UsuarioService.BuscarNaSessao(Session);
                if (usuario != null)
                {
                    PostagemService.Adicionar(homeViewModel.NovaPostagem.Corpo, usuario.ID);
                }
                return Home();
            }
            catch (Exception exception)
            {
                return HttpNotFound(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult Logout(Usuario _usuario)
        {
            return View(nameof(Login));
        }
        #endregion
    }
}