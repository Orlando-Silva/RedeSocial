using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPostagemService<T> where T : class
    {
        T Adicionar(string conteudo, int autorID);
        T Inativar(int postagemID);
        List<T> BuscarPostagensFeed(int usuarioID);
        List<T> BuscarPostagensPerfil(int usuarioID);
    }
}
