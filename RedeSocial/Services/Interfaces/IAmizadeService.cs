#region --Using--
using Core.Entidades;
using Core.Enums;
using System.Collections.Generic;
#endregion

namespace Services.Interfaces
{
    public interface IAmizadeService<T> where T : Amizades 
    {
        T Adicionar(int solicitanteID, int convidadoID);
        T Verificar(int solicitanteID, int convidadoID);
        T Atualizar(int amizadeID, Status status);
        T Buscar(int solicitanteID, int convidadoID);
        List<T> Buscar(int usuarioID, Status status);
        List<Usuario> BuscarAmigos(int usuarioID, Status status);
    }
}
