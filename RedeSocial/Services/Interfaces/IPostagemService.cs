#region --Using--
using Core.Enums;
using System.Collections.Generic;
#endregion

namespace Services.Interfaces
{
    public interface IPostagemService<T> where T : class
    {
        T Adicionar(string conteudo, int autorID);

        T Buscar(int id);
        List<T> BuscarPostagensFeed(int usuarioID);
        List<T> BuscarPostagensPerfil(int usuarioID);

        T AlterarStatus(int postagemID, Status status);
    }
}
