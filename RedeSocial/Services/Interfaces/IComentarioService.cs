#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Services.Interfaces
{
    public interface IComentarioService<T> where T : Comentario
    {
        T Adicionar(string conteudo, int autorID, int postagemID);
        List<Comentario> BuscarPorPostagem(int postagemID);
    }
}
