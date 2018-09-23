#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.Repositórios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        bool Existe(Usuario usuario);
        Usuario BuscarPorLoginSenha(string login, string senha);
        List<Usuario> BuscarPorNome(string nome);
    }
}
