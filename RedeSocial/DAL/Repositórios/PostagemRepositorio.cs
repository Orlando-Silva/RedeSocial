#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Data.Entity;
#endregion

namespace DAL.Repositórios
{
    public class PostagemRepositorio : Repositorio<Postagem>, IPostagemRepositorio
    {
        public PostagemRepositorio(DbContext _contexto) : base(_contexto) { }
    }
}
