#region --Using--
using Core.Entidades;
using System.Web;
#endregion

namespace Services.Interfaces
{
    public interface IUsuarioService<T> where T : Usuario
    {
        void IniciarSessao(HttpSessionStateBase sessao, T usuario);
        void FinalizarSessao(HttpSessionStateBase sessao);
        T BuscarNaSessao(HttpSessionStateBase sessao);
        T BuscarPorID(int ID);
        T Adicionar(Usuario _usuario);
        T Atualizar(Usuario _usuario);
        T Inativar(int usuarioID);     
    }
}
