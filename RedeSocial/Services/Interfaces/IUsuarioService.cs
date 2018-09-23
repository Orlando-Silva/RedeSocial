#region --Using--
using Core.Entidades;
using System.Collections.Generic;
using System.Web;
#endregion

namespace Services.Interfaces
{
    public interface IUsuarioService<T> where T : Usuario
    {
        T BuscarPorID(int ID);     
        T Inativar(int usuarioID);
        T Adicionar(Usuario _usuario);
        T Atualizar(Usuario _usuario);
        T BuscarNaSessao(HttpSessionStateBase sessao);
        void IniciarSessao(HttpSessionStateBase sessao, T usuario);
        void FinalizarSessao(HttpSessionStateBase sessao);
        List<T> BuscarPorNome(string nome);
    }
}
