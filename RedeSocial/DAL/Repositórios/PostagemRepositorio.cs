#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class PostagemRepositorio : Repositorio<Postagem>, IPostagemRepositorio
    {
        #region --Construtor--
        public PostagemRepositorio(DbContext _contexto) : base(_contexto) { }
        #endregion

        public IEnumerable<Postagem> BuscarPorUsuario(int usuarioID) => Entidades.Where(_ => _.Autor.ID == usuarioID);

        public IEnumerable<Postagem> BuscarFeed(int usuarioID, List<Amizades> amigos) => Entidades.Include(_ => _.Autor.Fotos).Where(_ => _.Autor.ID == usuarioID || amigos.Select(a => a.Solicitante.ID).Contains(_.Autor.ID) || amigos.Select(a => a.Convidado.ID).Contains(_.Autor.ID));
    }
}
