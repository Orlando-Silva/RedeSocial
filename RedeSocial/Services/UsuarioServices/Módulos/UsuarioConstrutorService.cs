#region --Using--
using Core.Entidades;
using Core.Enums;
using Core.ViewModels;
using Helpers;
using Services.Estruturas;
using Services.UsuarioServices.Módulos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Services.UsuarioServices.Módulos
{
    public class UsuarioConstrutorService : Construtor<Usuario>, IUsuarioConstrutorService<Usuario>
    {
        #region --IUsuarioConstrutor--
        #region --Construtores--
        public UsuarioConstrutorService(Usuario _usuario) : base(_usuario)
        {

        }

        public UsuarioConstrutorService() : base()
        {

        }
        #endregion

        #region --Construtores de Atributos--
        public IUsuarioConstrutorService<Usuario> ComNome(string nome)
        {
            Entidade.Nome = nome ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(nome) } não pode ser nulo.", paramName: nameof(nome));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComSenha(string senha)
        {
            if (senha is null)
                throw new ArgumentNullException(message: $"O parâmetro { nameof(senha) } não pode ser nulo.", paramName: nameof(senha));

            Entidade.Senha = Seguranca.Encriptar(senha).ToString();
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComEmail(string email)
        {
            Entidade.Email = email ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(email) } não pode ser nulo.", paramName: nameof(email));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComLogin(string login)
        {
            Entidade.Login = login ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(login) } não pode ser nulo.", paramName: nameof(login));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComTelefone(string telefone)
        {
            Entidade.Telefone = telefone ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(telefone) } não pode ser nulo.", paramName: nameof(telefone));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> CriadoEm(DateTime criado)
        {
            Entidade.Criado = criado;
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NasceuEm(DateTime dataDeNascimento)
        {
            Entidade.DataDeNascimento = dataDeNascimento;
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NoEndereco(string endereco)
        {
            Entidade.Endereco = endereco ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(endereco) } não pode ser nulo.", paramName: nameof(endereco));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NaCidade(string cidade)
        {
            Entidade.Cidade = cidade ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(cidade) } não pode ser nulo.", paramName: nameof(cidade));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NoEstado(string estado)
        {
            Entidade.Estado = estado ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(estado) } não pode ser nulo.", paramName: nameof(estado));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NoPais(string pais)
        {
            Entidade.Pais = pais ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(pais) } não pode ser nulo.", paramName: nameof(pais));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComComplemento(string complemento)
        {
            Entidade.Complemento = complemento ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(complemento) } não pode ser nulo.", paramName: nameof(complemento));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComFotos(IList<FotoDePerfil> fotos)
        {
            Entidade.Fotos = fotos.Any() ? fotos : throw new ArgumentNullException(message: $"O parâmetro { nameof(fotos) } não pode ser nulo.", paramName: nameof(fotos));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NovaFoto(FotoDePerfil foto)
        {
            Entidade.Fotos.Add(foto);
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComPostagens(IList<Postagem> postagems)
        {
            Entidade.Postagens = postagems.Any() ? postagems : throw new ArgumentNullException(message: $"O parâmetro { nameof(postagems) } não pode ser nulo.", paramName: nameof(postagems));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NovaPostagem(Postagem postagem)
        {
            Entidade.Postagens.Add(postagem);
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComComentarios(IList<Comentario> comentarios)
        {
            Entidade.Comentarios = comentarios.Any() ? comentarios : throw new ArgumentNullException(message: $"O parâmetro { nameof(comentarios) } não pode ser nulo.", paramName: nameof(comentarios));
            return this;
        }

        public IUsuarioConstrutorService<Usuario> NovoComentario(Comentario comentario)
        {
            Entidade.Comentarios.Add(comentario);
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public IUsuarioConstrutorService<Usuario> ComDescricao(string descricao)
        {
            Entidade.Descricao = descricao ?? throw new ArgumentNullException(message: $"O parâmetro { nameof(descricao) } não pode ser nulo.", paramName: nameof(descricao));
            return this;
        }
        #endregion

        public Usuario Montar(NovoUsuarioViewModel novoUsuarioViewModel)
        {
            return (Usuario) CriadoEm(DateTime.UtcNow)
                            .ComLogin(novoUsuarioViewModel.Login)
                            .ComEmail(novoUsuarioViewModel.Email)
                            .ComSenha(novoUsuarioViewModel.Senha)
                                .ComNome(novoUsuarioViewModel.Nome)
                                .ComTelefone(novoUsuarioViewModel.Telefone)
                                .NasceuEm(novoUsuarioViewModel.DataDeNascimento)
                                    .NoPais(novoUsuarioViewModel.Pais)
                                    .NoEstado(novoUsuarioViewModel.Estado)
                                    .NaCidade(novoUsuarioViewModel.Cidade)
                                    .NoEndereco(novoUsuarioViewModel.Endereco)
                                    .ComComplemento(novoUsuarioViewModel.Complemento);
        }
        #endregion
    }
}
