#region --Using--
using Core.Entidades;
#endregion

namespace Core.Repositórios
{
    public interface IFotoDePerfilRepositorio : IRepositorio<FotoDePerfil>
    {
        FotoDePerfil BuscarPorUsuario(int usuarioID);
    }
}
