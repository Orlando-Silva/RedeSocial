#region --Using--
using Core.Entidades;
using Core.Enums;
using Helpers;
using Services.Construtores.Core;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Services.Construtores
{
    public class ConstrutorUsuario : Construtor<Usuario>
    {
        #region --Construtores--
        public ConstrutorUsuario(Usuario _usuario) : base(_usuario)
        {

        }

        public ConstrutorUsuario() : base()
        {

        }
        #endregion

        #region --Construtores de Atributos--
        public ConstrutorUsuario ComNome(string nome)
        {
            Entidade.Nome = nome ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(nome) } não pode ser nulo.", paramName: nameof(nome));
            return this;
        }

        public ConstrutorUsuario ComSenha(string senha)
        {
            if (senha is null)
                throw new ArgumentNullException(message: $"O parâmetro { nameof(senha) } não pode ser nulo.", paramName: nameof(senha));

            Entidade.Senha = Seguranca.Encriptar(senha).ToString();
            return this;
        }

        public ConstrutorUsuario ComEmail(string email)
        {
            Entidade.Email = email ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(email) } não pode ser nulo.", paramName: nameof(email));
            return this;
        }

        public ConstrutorUsuario ComLogin(string login)
        {
            Entidade.Login = login ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(login) } não pode ser nulo.", paramName: nameof(login));
            return this;
        }

        public ConstrutorUsuario ComTelefone(string telefone)
        {
            Entidade.Telefone = telefone ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(telefone) } não pode ser nulo.", paramName: nameof(telefone));
            return this;
        }

        public ConstrutorUsuario CriadoEm(DateTime criado)
        {
            Entidade.Criado = criado;
            return this;
        }

        public ConstrutorUsuario NasceuEm(DateTime dataDeNascimento)
        {
            Entidade.DataDeNascimento = dataDeNascimento;
            return this;
        }

        public ConstrutorUsuario NoEndereco(string endereco)
        {
            Entidade.Endereco = endereco ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(endereco) } não pode ser nulo.", paramName: nameof(endereco));
            return this;
        }

        public ConstrutorUsuario NaCidade(string cidade)
        {
            Entidade.Cidade = cidade ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(cidade) } não pode ser nulo.", paramName: nameof(cidade));
            return this;
        }

        public ConstrutorUsuario NoEstado(string estado)
        {
            Entidade.Estado = estado ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(estado) } não pode ser nulo.", paramName: nameof(estado));
            return this;
        }

        public ConstrutorUsuario NoPais(string pais)
        {
            Entidade.Pais = pais ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(pais) } não pode ser nulo.", paramName: nameof(pais));
            return this;
        }

        public ConstrutorUsuario ComComplemento(string complemento)
        {
            Entidade.Complemento = complemento ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(complemento) } não pode ser nulo.", paramName: nameof(complemento));
            return this;
        }

        public ConstrutorUsuario ComFotos(IList<FotoDePerfil> fotos)
        {
            Entidade.Fotos = fotos.Any() ? fotos : throw new ArgumentNullException(message: $"O parâmetro { nameof(fotos) } não pode ser nulo.", paramName: nameof(fotos));
            return this;
        }

        public ConstrutorUsuario NovaFoto(FotoDePerfil foto)
        {
            Entidade.Fotos.Add(foto);
            return this;
        }

        public ConstrutorUsuario ComPostagens(IList<Postagem> postagems)
        {
            Entidade.Postagens = postagems.Any() ? postagems : throw new ArgumentNullException(message: $"O parâmetro { nameof(postagems) } não pode ser nulo.", paramName: nameof(postagems));
            return this;
        }

        public ConstrutorUsuario NovaPostagem(Postagem postagem)
        {
            Entidade.Postagens.Add(postagem);
            return this;
        }

        public ConstrutorUsuario ComComentarios(IList<Comentario> comentarios)
        {
            Entidade.Comentarios = comentarios.Any() ? comentarios : throw new ArgumentNullException(message: $"O parâmetro { nameof(comentarios) } não pode ser nulo.", paramName: nameof(comentarios));
            return this;
        }

        public ConstrutorUsuario NovoComentario(Comentario comentario)
        {
            Entidade.Comentarios.Add(comentario);
            return this;
        }

        public ConstrutorUsuario ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public ConstrutorUsuario ComDescricao(string descricao)
        {
            Entidade.Descricao = descricao ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(descricao) } não pode ser nulo.", paramName: nameof(descricao));
            return this;
        }
        #endregion

        public Usuario Montar(Usuario usuario) => CriadoEm(DateTime.UtcNow)
                                                    .ComLogin(usuario.Login)
                                                    .ComEmail(usuario.Email)
                                                    .ComSenha(usuario.Senha)
                                                        .ComNome(usuario.Nome)
                                                        .ComTelefone(usuario.Telefone)
                                                        .NasceuEm(usuario.DataDeNascimento)
                                                        .ComDescricao(usuario.Descricao)
                                                            .NoPais(usuario.Pais)
                                                            .NoEstado(usuario.Estado)
                                                            .NaCidade(usuario.Cidade)
                                                            .NoEndereco(usuario.Endereco)
                                                            .ComComplemento(usuario.Complemento);
    }
}
