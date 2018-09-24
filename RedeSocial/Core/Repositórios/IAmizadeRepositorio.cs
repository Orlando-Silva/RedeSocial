#region --Using--
using Core.Entidades;
using Core.Enums;
using System.Collections.Generic;
#endregion

namespace Core.Repositórios
{
    public interface IAmizadeRepositorio : IRepositorio<Amizade>
    {
        List<Amizade> BuscarAmizades(int usuarioID, Status status);
        List<Usuario> BuscarAmigos(int usuarioID, Status status);
    }
}
