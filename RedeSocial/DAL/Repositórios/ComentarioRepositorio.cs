#region --Using--
using System.Collections.Generic;
using System.Linq;
using Core.Entidades;
using Core.Repositórios;
using DAL.Contexto;
#endregion

namespace DAL.Repositórios
{
    public class ComentarioRepositorio : Repositorio<Comentario>, IComentarioRepositorio
    {
        #region --Atributos--
        private RedeSocialContexto RedeSocialContexto
        {
            get => Contexto as RedeSocialContexto; 
        }
        #endregion

        public ComentarioRepositorio(RedeSocialContexto _contexto) : base(_contexto) { }

        public List<Comentario> BuscarPorPostagem(int postagemID)
        {
            return RedeSocialContexto.Postagens.Where(_ => _.ID == postagemID).Select(_ => _.Comentarios) as List<Comentario>;
        }
    }
}
