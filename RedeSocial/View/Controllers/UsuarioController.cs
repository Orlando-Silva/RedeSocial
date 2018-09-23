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
             var usuario = UsuarioService.BuscarNaSessao(Session);
            if (usuario is Usuario)
            {
                return View(nameof(Home), new HomeViewModel
                {
                    Usuario = usuario,
                    FotoDePerfil = FotoDePerfilService.Buscar(usuario.ID),
                    Postagens = PostagemService.BuscarPostagensFeed(usuario.ID)
                });
            }
            else
            {
                return View(nameof(Login));
            }
        }

        [HttpGet]
        public ActionResult BuscarUsuarios(string nome)
        {
            var usuarios = UsuarioService.BuscarPorNome(nome);
            var usuarioLogado = UsuarioService.BuscarNaSessao(Session);
            return View(
                new BuscarUsuariosViewModel {
                    Usuarios = usuarios,
                    AmizadesUsuarioLogado = AmizadeService.Buscar(usuarioLogado.ID, Core.Enums.Status.Ativo),
                    UsuarioLogado = usuarioLogado
                });
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
                    Usuario = usuarioPerfil,
                    UsuarioEdicao = usuario,
                    Amigos = AmizadeService.BuscarAmigos(usuarioPerfil.ID, Core.Enums.Status.Ativo),
                    Postagens = PostagemService.BuscarPostagensPerfil(usuarioPerfil.ID),
                    FotoDePerfil = FotoDePerfilService.Buscar(usuario.ID),
                    PodeEditar = usuarioPerfil.ID == usuario.ID,
                    FU_pass = encryptedID
                });
            }
            else
            {
                return View(nameof(Login));
            }
        }

        public ActionResult AdicionarAmigo(int convidadoID)
        {
            var usuario = UsuarioService.BuscarNaSessao(Session);
            if(usuario != null)
            {
                var convidado = UsuarioService.BuscarPorID(convidadoID);
                if(convidado != null)
                {
                    var amizade = AmizadeService.Adicionar(usuario.ID, convidado.ID);
                }

            }
            return Home();
        }

        public ActionResult DesfazerAmizade(int convidadoID)
        {
            var usuarioConvidado = UsuarioService.BuscarPorID(convidadoID);
            var usuarioSession = UsuarioService.BuscarNaSessao(Session);
            var amizade = AmizadeService.Buscar(usuarioSession.ID, usuarioConvidado.ID);
            AmizadeService.Atualizar(amizade.ID, Core.Enums.Status.Inativo);
            return Home();
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
        public ActionResult AtualizarAvatar(HttpPostedFileBase FotoDePerfil, PerfilViewModel perfilViewModel)
        {
            try
            {
                var usuarioID = int.Parse(Seguranca.Decriptar(perfilViewModel.FU_pass));
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
        #endregion
    }
}