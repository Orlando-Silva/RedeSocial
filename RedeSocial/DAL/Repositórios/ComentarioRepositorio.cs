#region --Using--
using Core.Entidades;
using Core.Repositórios;
using DAL.Contexto;
#endregion

namespace DAL.Repositórios
{
    public class ComentarioRepositorio : Repositorio<Comentario>, IComentarioRepositorio
    {
        public ComentarioRepositorio(RedeSocialContexto _contexto) : base(_contexto) { }
    }
}
