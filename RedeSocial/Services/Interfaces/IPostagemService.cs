#region --Using--
using System.Collections.Generic;
#endregion

namespace Services.Interfaces
{
    public interface IPostagemService<T> where T : class
    {
        T Adicionar(string conteudo, int autorID);

        List<T> BuscarPostagensFeed(int usuarioID);
        List<T> BuscarPostagensPerfil(int usuarioID);

        T Inativar(int postagemID);
    }
}
