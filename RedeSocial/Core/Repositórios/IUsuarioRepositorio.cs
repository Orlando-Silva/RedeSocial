#region --Using--
using Core.Entidades;
#endregion

namespace Core.Repositórios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        bool Existe(Usuario usuario);
        Usuario BuscarPorLoginSenha(string login, string senha);
    }
}
