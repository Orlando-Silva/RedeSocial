#region --Using--
using Core.Entidades;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Builders
{
    public class UsuarioBuilder : Builder<Usuario>
    {
        #region --Construtores de Usuário--
        public UsuarioBuilder ComNome(string nome)
        {
            Entidade.Nome = nome ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(nome) } não pode ser nulo.", paramName: nameof(nome));
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            if (senha is null)
                throw new ArgumentNullException(message: $"O parâmetro { nameof(senha) } não pode ser nulo.", paramName: nameof(senha));

            Entidade.Senha = Seguranca.ComputeHash(senha, Seguranca.GenerateSalt()).ToString();
            return this;
        }

        public UsuarioBuilder ComLogin(string login)
        {
            Entidade.Login = login ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(login) } não pode ser nulo.", paramName: nameof(login));
            return this;
        }

        public UsuarioBuilder NaRua(string rua)
        {
            Entidade.Rua = rua ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(rua) } não pode ser nulo.", paramName: nameof(rua));
            return this;
        }

        public UsuarioBuilder NaCidade(string cidade)
        {
            Entidade.Cidade = cidade ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(cidade) } não pode ser nulo.", paramName: nameof(cidade));
            return this;
        }

        public UsuarioBuilder NoEstado(string estado)
        {
            Entidade.Estado = estado ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(estado) } não pode ser nulo.", paramName: nameof(estado));
            return this; 
        }

        public UsuarioBuilder NoPais(string pais)
        {
            Entidade.Pais = pais ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(pais) } não pode ser nulo.", paramName: nameof(pais));
            return this;
        }

        public UsuarioBuilder ComAmigos(IList<Usuario> amigos)
        {
            Entidade.Amigos = amigos.Any() ? amigos : throw new ArgumentNullException(message: $"O parâmetro { nameof(amigos) } não pode ser nulo.", paramName: nameof(amigos));
            return this;
        }

        public UsuarioBuilder ComFotos(IList<FotoDePerfil> fotos)
        {
            Entidade.Fotos = fotos.Any() ? fotos : throw new ArgumentNullException(message: $"O parâmetro { nameof(fotos) } não pode ser nulo.", paramName: nameof(fotos));
            return this;
        }

        public UsuarioBuilder ComPostagens(IList<Postagem> postagems)
        {
            Entidade.Postagens = postagems.Any() ? postagems : throw new ArgumentNullException(message: $"O parâmetro { nameof(postagems) } não pode ser nulo.", paramName: nameof(postagems));
            return this;
        }

        public UsuarioBuilder ComComentarios(IList<Comentario> comentarios)
        {
            Entidade.Comentarios = comentarios.Any() ? comentarios : throw new ArgumentNullException(message: $"O parâmetro { nameof(comentarios) } não pode ser nulo.", paramName: nameof(comentarios));
            return this;
        }
        #endregion
    }
}
