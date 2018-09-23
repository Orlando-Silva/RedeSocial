#region --Using--
using Core.Entidades;
using Core.Repositórios;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DAL.Repositórios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContext _contexto) : base(_contexto) { }

        public Usuario BuscarPorLoginSenha(string login, string senha) => Entidades.Include(_ => _.Fotos).FirstOrDefault(_ => _.Login == login && _.Senha == senha);

        public bool Existe(Usuario usuario) => Entidades.Any(_ => _.ID == usuario.ID);
    }
}
