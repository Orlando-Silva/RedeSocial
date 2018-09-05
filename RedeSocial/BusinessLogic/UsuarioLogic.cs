#region --Using--
using Builders;
using Core.Entidades;
using System;
#endregion

namespace BusinessLogic
{
    public class UsuarioLogic : Base
    {
        #region --Métodos Públicos--
        public static void Adicionar(Usuario usuario)
        {
            usuario = Preparar(usuario);
            UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
            UnidadeDeTrabalho.Encerrar();
        }
        #endregion

        #region --Métodos Privados--
        private static Usuario Preparar(Usuario usuario)
        {
            if (usuario is null)
                throw new ArgumentNullException("O usuário não pode ser nulo!");

            return new UsuarioBuilder(usuario)
                            .ComSenha(usuario.Senha);      
        }
        #endregion
    }
}
