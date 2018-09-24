#region --Using--
using Core.Entidades;
using System.Collections.Generic;
using System.Web;
#endregion

namespace Services.Interfaces
{
    public interface IUsuarioService<T> where T : Usuario
    {
        T Adicionar(Usuario _usuario);
        T Atualizar(Usuario _usuario);

        T BuscarPorID(int ID);
        List<T> BuscarPorNome(string nome);

        void FinalizarSessao(HttpSessionStateBase sessao);

        T Inativar(int usuarioID);
        void IniciarSessao(HttpSessionStateBase sessao, T usuario);
    }
}
