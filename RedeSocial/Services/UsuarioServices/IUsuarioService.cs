#region --Using--
using Core.Entidades;
using Services.UsuarioServices.Módulos.Interfaces;
#endregion

namespace Services.UsuarioServices
{
    public interface IUsuarioService<T> : IUsuarioConstrutorService<T>, IUsuarioLogin<T>, IUsuarioOperacoesBasicas<T>  where T : Usuario
    {
    }
}
