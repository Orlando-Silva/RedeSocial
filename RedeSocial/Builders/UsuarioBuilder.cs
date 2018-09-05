#region --Using--
using Core.Entidades;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Builders
{
    public class UsuarioBuilder
    {
        #region --Atributos--
        private static Usuario Usuario { get; set; }
        #endregion

        #region --Construtores--
        /// <summary>
        /// Inicializa um construtor de usuário para um novo usuário.
        /// </summary>
        public UsuarioBuilder()
        {
            Usuario = new Usuario();
        }
        /// <summary>
        /// Inicializa um construtor de usuário para um usuário existente.
        /// </summary>
        public UsuarioBuilder(Usuario _usuario)
        {
            Usuario = _usuario ?? throw new ArgumentNullException("Usuário nulo.");
        }
        #endregion

        #region --Construtores de Usuário--
        public UsuarioBuilder ComNome(string nome)
        {
            Usuario.Nome = nome ?? throw new ArgumentNullException("Nome nulo.");
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            if (senha is null)
                throw new ArgumentNullException("Senha nula.");
            
            Usuario.Senha = Seguranca.ComputeHash(senha, Seguranca.GenerateSalt()).ToString();
            return this;
        }

        public UsuarioBuilder ComLogin(string login)
        {
            Usuario.Login = login ?? throw new ArgumentNullException("Login nulo.");
            return this;
        }

        public UsuarioBuilder NaRua(string rua)
        {
            Usuario.Rua = rua ?? throw new ArgumentNullException("Rua nula.");
            return this;
        }

        public UsuarioBuilder NaCidade(string cidade)
        {
            Usuario.Cidade = cidade ?? throw new ArgumentNullException("Cidade nula.");
            return this;
        }

        public UsuarioBuilder NoEstado(string estado)
        {
            Usuario.Estado = estado ?? throw new ArgumentNullException("Estado nulo.");
            return this;
        }

        public UsuarioBuilder NoPais(string pais)
        {
            Usuario.Pais = pais ?? throw new ArgumentNullException("País nulo.");
            return this;
        }

        public UsuarioBuilder ComAmigos(IList<Usuario> amigos)
        {
            Usuario.Amigos = amigos.Any() ? amigos : throw new ArgumentNullException("Lista de amigos nula.");
            return this;
        }

        public UsuarioBuilder ComFotos(IList<FotoDePerfil> fotos)
        {
            Usuario.Fotos = fotos.Any() ? fotos : throw new ArgumentNullException("Lista de fotos nula.");
            return this;
        }

        public UsuarioBuilder ComPostagens(IList<Postagem> postagems)
        {
            Usuario.Postagens = postagems.Any() ? postagems : throw new ArgumentNullException("Lista de postagens nula.");
            return this;
        }

        public UsuarioBuilder ComComentarios(IList<Comentario> comentarios)
        {
            Usuario.Comentarios = comentarios.Any() ? comentarios : throw new ArgumentNullException("Lista de comentários nula.");
            return this;
        }
        #endregion

        #region --Operador de Conversão Implicita--
        public static implicit operator Usuario(UsuarioBuilder _usuarioBuilder) => Usuario;
        #endregion
    }
}
