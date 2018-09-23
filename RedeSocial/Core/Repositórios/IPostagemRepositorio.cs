#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.Repositórios
{
    public interface IPostagemRepositorio : IRepositorio<Postagem>
    {
        IEnumerable<Postagem> BuscarPorUsuario(int usuarioID);
        IEnumerable<Postagem> Buscar(int usuarioID, List<int> amigosID);
    }
}
