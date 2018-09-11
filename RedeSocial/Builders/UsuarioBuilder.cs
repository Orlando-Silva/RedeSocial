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
        #region --Construtor--
        public UsuarioBuilder(Usuario _usuario) : base(_usuario)
        {

        }
        #endregion

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

        public UsuarioBuilder ComEmail(string email)
        {
            Entidade.Email = email ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(email) } não pode ser nulo.", paramName: nameof(email));
            return this;
        }

        public UsuarioBuilder ComLogin(string login)
        {
            Entidade.Login = login ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(login) } não pode ser nulo.", paramName: nameof(login));
            return this;
        }

        public UsuarioBuilder ComTelefone(string telefone)
        {
            Entidade.Telefone = telefone ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(telefone) } não pode ser nulo.", paramName: nameof(telefone));
            return this;
        }

        public UsuarioBuilder CriadoEm(DateTime criado)
        {
            Entidade.Criado = criado ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(criado) } não pode ser nulo.", paramName: nameof(criado));
            return this;
        }

        public UsuarioBuilder NasceuEm(DateTime dataDeNascimento)
        {
            Entidade.DataDeNascimento = dataDeNascimento ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(dataDeNascimento) } não pode ser nulo.", paramName: nameof(dataDeNascimento));
            return this;
        }

        public UsuarioBuilder NoEndereco(string endereco)
        {
            Entidade.Endereco = endereco ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(endereco) } não pode ser nulo.", paramName: nameof(endereco));
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
