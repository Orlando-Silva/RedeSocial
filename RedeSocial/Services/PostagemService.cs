#region --Using--
using Core.Entidades;
using Core.Enums;
using DAL;
using Services.Construtores;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Services
{
    public class PostagemService : Service, IPostagemService<Postagem>
    {
        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public PostagemService()
        {

        }
        #endregion

        public List<Postagem> BuscarPostagensPerfil(int usuarioID) => UnidadeDeTrabalho.Postagens.BuscarPorUsuario(usuarioID).ToList();

        public Postagem Adicionar(string conteudo, int autorID)
        {
            var postagem = new ConstrutorPostagem().Montar(conteudo, autorID);
            UnidadeDeTrabalho.Postagens.Adicionar(postagem);
            UnidadeDeTrabalho.Encerrar();
            return postagem;
        }

        public List<Postagem> BuscarPostagensFeed(int usuarioID)
        {
            //TODO :Alterar assim que criar o sistema de amizades:
            var amigos = UnidadeDeTrabalho.Amizades.BuscarTodos(_ => _.Convidado.ID == usuarioID || _.Solicitante.ID == usuarioID).ToList();

            var postagens = UnidadeDeTrabalho.Postagens.BuscarFeed(usuarioID, amigos).ToList();
            return postagens;
        }

        public Postagem Inativar(int postagemID)
        {
            var postagem = UnidadeDeTrabalho.Postagens.Buscar(postagemID);

            postagem = new ConstrutorPostagem(postagem)
                        .ComStatus(Status.Ativo);

            UnidadeDeTrabalho.Encerrar();
            return postagem;

        }
    }
}
