#region --Using--
using Builders;
using Core.Entidades;
using Core.Exceptions;
using Core.ViewModels;
using Helpers;
using System;
using System.Web;
#endregion

namespace BusinessLogic
{
    public class UsuarioLogic : Alicerce, 
    {
        public static void Adicionar(HttpSessionStateBase sessionAtual,NovoUsuarioViewModel _usuario)
        {
            ValidarUsuario(_usuario);
            var usuario = Preparar(_usuario);

            var UnidadeDeTrabalho = BuscarUnidadeDeTrabalho();
            UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
            UnidadeDeTrabalho.Encerrar();
            SessionHelper.StoreInSession(sessionAtual, usuario);
        }

       
    }
}
