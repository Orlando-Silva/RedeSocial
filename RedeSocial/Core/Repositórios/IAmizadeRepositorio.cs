#region --Using--
using Core.Entidades;
using Core.Enums;
using System.Collections.Generic;
#endregion

namespace Core.Repositórios
{
    public interface IAmizadeRepositorio : IRepositorio<Amizades>
    {
        List<Amizades> BuscarAmizades(int usuarioID, Status status);
        List<Usuario> BuscarAmigos(int usuarioID, Status status);
    }
}
