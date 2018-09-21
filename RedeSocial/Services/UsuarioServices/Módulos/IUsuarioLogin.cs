#region --Using--
using Core.Entidades;
using Core.ViewModels;
using Helpers;
using System.Web;
#endregion

namespace Services.UsuarioServices.Módulos.Interfaces
{
    public interface IUsuarioLogin<T> : IValidadorDeSessao<T> where T : Usuario
    {
        void IniciarSessao(HttpSessionStateBase sessao, T usuario);
        void FinalizarSessao(HttpSessionStateBase sessao);
        T BuscarNaSessao(HttpSessionStateBase sessao);
    }
}
