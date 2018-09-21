#region --Using--
using System;
using System.Web;
using Core.Entidades;
using Helpers;
using Services.Estruturas;
using Services.UsuarioServices.Módulos.Interfaces;
#endregion

namespace Services.UsuarioServices.Módulos
{
    public class UsuarioLoginService : Service, IUsuarioLogin<Usuario>
    {
        public Usuario BuscarNaSessao(HttpSessionStateBase sessao) => SessionHelper.BuscarNaSessao(sessao, this);

        public void IniciarSessao(HttpSessionStateBase sessao, Usuario usuario) => SessionHelper.AdicionarNaSessao(sessao, usuario);

        public bool ValidarSessao(Usuario entidade) => BuscarUnidadeDeTrabalho().Usuarios.Existe(entidade);

        public void FinalizarSessao(HttpSessionStateBase sessao)
        {
            throw new NotImplementedException();
        }
    }
}
