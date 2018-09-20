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
    public class UsuarioLogic : Base, IEntityValidator<Usuario>
    {
        #region --Métodos Públicos--
        public static void Adicionar(HttpSessionStateBase sessionAtual,NovoUsuarioViewModel _usuario)
        {
            ValidarUsuario(_usuario);
            var usuario = Preparar(_usuario);

            var UnidadeDeTrabalho = BuscarUnidadeDeTrabalho();
            UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
            UnidadeDeTrabalho.Encerrar();
            SessionHelper.StoreInSession(sessionAtual, usuario);
        }

        public static Usuario Login(HttpSessionStateBase sessionAtual, LoginViewModel _usuario)
        {
            if (string.IsNullOrWhiteSpace(_usuario.Login) || string.IsNullOrWhiteSpace(_usuario.Senha))
            {
                throw new ArgumentNullException();
            }

            var UnidadeDeTrabalho = BuscarUnidadeDeTrabalho();
            _usuario.Senha = Seguranca.Encrypt(_usuario.Senha);
            var usuario = UnidadeDeTrabalho.Usuarios.BuscarPorLoginSenha(_usuario.Login, _usuario.Senha) ?? throw new LoginException("Login ou senha incorretos.");
            SessionHelper.StoreInSession(sessionAtual, usuario);
            return usuario;

        }

        public static bool EstaLogado(HttpSessionStateBase currentSession)
        {
            var usuario = SessionHelper.GetSessionObject(currentSession, new UsuarioLogic());
            return usuario != null;
        }

        public static Usuario BuscarDaSession(HttpSessionStateBase currentSession) => SessionHelper.GetSessionObject(currentSession, new UsuarioLogic());
        
        public bool IsValid(Usuario entidade) => BuscarUnidadeDeTrabalho().Usuarios.Existe(entidade);

        public static Usuario BuscarPorId(int usuarioID) => BuscarUnidadeDeTrabalho().Usuarios.Buscar(usuarioID);
        #endregion

        #region --Métodos Privados--
        private static void ValidarUsuario(NovoUsuarioViewModel _usuario)
        {

            if (_usuario.Senha != _usuario.ConfirmacaoSenha)
            {
                throw new Exception("Os valores do campo Senha e Confirme Sua Senha devem ser iguais.");
            }

            if (_usuario.DataDeNascimento > DateTime.UtcNow)
            {
                throw new Exception("Data de nascimento inválida.");
            }
        }

        private static Usuario Preparar(NovoUsuarioViewModel _usuario)
        {
            if (_usuario is null)
            {
                throw new ArgumentNullException(message: $"O parâmetro { nameof(_usuario) } não pode ser nulo.", paramName: nameof(_usuario));
            }

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
