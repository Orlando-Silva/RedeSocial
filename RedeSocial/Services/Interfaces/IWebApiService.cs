#region --Using--
using Core.Entidades;
#endregion

namespace Services.Interfaces
{
    public interface IWebApiService
    {
        object BuscarUsuario(int id);
        bool UsuarioEstaCadastrado(string email);
    }
}
