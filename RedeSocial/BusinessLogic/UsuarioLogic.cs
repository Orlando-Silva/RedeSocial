#region --Using--
using Builders;
using Core.Entidades;
using Core.ViewModels;
using System;
#endregion

namespace BusinessLogic
{
    public class UsuarioLogic : Base
    {
        #region --Métodos Públicos--
        public static void Adicionar(NovoUsuarioViewModel _usuario)
        {
            ValidarUsuario(_usuario);
            var usuario = Preparar(_usuario);

            using (var UnidadeDeTrabalho = BuscarUnidadeDeTrabalho())
            { 
                UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
                UnidadeDeTrabalho.Encerrar();
            }

        }
        #endregion

        #region --Métodos Privados--
        private static void ValidarUsuario(NovoUsuarioViewModel _usuario)
        {

            if (_usuario.Senha != _usuario.ConfirmacaoSenha)
                throw new Exception("Os valores do campo Senha e Confirme Sua Senha devem ser iguais.");

            if (_usuario.DataDeNascimento > DateTime.UtcNow)
                throw new Exception("Data de nascimento inválida.");

        }

        private static Usuario Preparar(NovoUsuarioViewModel _usuario)
        {
            if (_usuario is null) 
                throw new ArgumentNullException(message: $"O parâmetro { nameof(_usuario) } não pode ser nulo.", paramName: nameof(_usuario));

            return new UsuarioBuilder()
                            .CriadoEm(DateTime.UtcNow)
                            .ComLogin(_usuario.Login)
                            .ComEmail(_usuario.Email)
                            .ComSenha(_usuario.Senha)
                                .ComNome(_usuario.Nome)    
                                .ComTelefone(_usuario.Telefone)
                                .NasceuEm(_usuario.DataDeNascimento)
                                    .NoPais(_usuario.Pais)
                                    .NoEstado(_usuario.Estado)
                                    .NaCidade(_usuario.Cidade)
                                    .NoEndereco(_usuario.Endereco)
                                    .ComComplemento(_usuario.Complemento);
        }
        #endregion
    }
}
