#region --Using--
using Core.Entidades;
using Core.ViewModels;
using Services.UsuarioServices.Módulos.Interfaces;
using System.Web;
#endregion

namespace Services.Interfaces
{
    public interface IUsuarioService<T> where T : Usuario
    {
        void IniciarSessao(HttpSessionStateBase sessao, T usuario);
        void FinalizarSessao(HttpSessionStateBase sessao);
        T BuscarNaSessao(HttpSessionStateBase sessao);
        T Adicionar(Usuario _usuario);
        T Inativar(int usuarioID);
        T Atualizar(Usuario usuario);
    }
}
