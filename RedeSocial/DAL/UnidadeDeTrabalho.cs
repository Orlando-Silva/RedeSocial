#region --Using--
using Core;
using Core.Repositórios;
using DAL.Contexto;
using DAL.Repositórios;
#endregion

namespace DAL
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        #region --Atributos--
        private readonly RedeSocialContexto Contexto;

        public IComentarioRepositorio Comentarios { get; private set; }

        public IFotoDePerfilRepositorio FotosDePerfil { get; private set; }

        public IPostagemRepositorio Postagens { get; private set; }

        public IUsuarioRepositorio Usuarios { get; private set; }

        public IAmizadeRepositorio Amizades { get; private set; }
        #endregion

        #region --Construtor--
        public UnidadeDeTrabalho(RedeSocialContexto _contexto)
        {
            Contexto = _contexto;
            Comentarios = new ComentarioRepositorio(_contexto);
            FotosDePerfil = new FotoDePerfilRepositorio(_contexto);
            Postagens = new PostagemRepositorio(_contexto);
            Usuarios = new UsuarioRepositorio(_contexto);
            Amizades = new AmizadeRepositorio(_contexto);
        }
        #endregion

        public void Encerrar() => Contexto.SaveChanges();

        public void Dispose() => Contexto.Dispose();
    }
}
