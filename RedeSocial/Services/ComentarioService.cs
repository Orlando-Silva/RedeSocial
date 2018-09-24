#region --Using--
using Core.Entidades;
using DAL;
using Services.Construtores;
using Services.Interfaces;
using System.Collections.Generic;
#endregion

namespace Services
{
    public class ComentarioService : Service, IComentarioService<Comentario>
    {
        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public ComentarioService()
        {

        }
        #endregion

        public Comentario Adicionar(string conteudo, int autorID, int postagemID)
        {
            var comentario = new ConstrutorComentario().Montar(conteudo, autorID);
            UnidadeDeTrabalho.Comentarios.Adicionar(comentario);

            var postagem = UnidadeDeTrabalho.Postagens.Buscar(postagemID);
            postagem = new ConstrutorPostagem(postagem).ComComentario(comentario);

            UnidadeDeTrabalho.Encerrar();
            return comentario;
        }

        public List<Comentario> BuscarPorPostagem(int postagemID)
        {
            return UnidadeDeTrabalho.Comentarios.BuscarPorPostagem(postagemID);
        }
    }
}
