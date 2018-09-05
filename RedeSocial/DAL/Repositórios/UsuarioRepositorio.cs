#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Data.Entity;
#endregion

namespace DAL.Repositórios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContext _contexto) : base(_contexto) { }
    }
}
