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
            Entidade.Nome = nome;
            return this;
        }

        public ConstrutorUsuario ComSenha(string senha, bool encriptar)
        {
            Entidade.Senha = encriptar ? Seguranca.Encriptar(senha) : senha;
            return this;
        }

        public ConstrutorUsuario ComEmail(string email)
        {
            Entidade.Email = email;
            return this;
        }

        public ConstrutorUsuario ComLogin(string login)
        {
            Entidade.Login = login;
            return this;
        }

        public ConstrutorUsuario ComTelefone(string telefone)
        {
            Entidade.Telefone = telefone;
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
            Entidade.Endereco = endereco;
            return this;
        }

        public ConstrutorUsuario NaCidade(string cidade)
        {
            Entidade.Cidade = cidade;
            return this;
        }

        public ConstrutorUsuario NoEstado(string estado)
        {
            Entidade.Estado = estado;
            return this;
        }

        public ConstrutorUsuario NoPais(string pais)
        {
            Entidade.Pais = pais;
            return this;
        }

        public ConstrutorUsuario ComComplemento(string complemento)
        {
            Entidade.Complemento = complemento;
            return this;
        }

        public ConstrutorUsuario ComFotos(IList<FotoDePerfil> fotos)
        {
            Entidade.Fotos = fotos;
            return this;
        }

        public ConstrutorUsuario NovaFoto(FotoDePerfil foto)
        {
            Entidade.Fotos.Add(foto);
            return this;
        }

        public ConstrutorUsuario ComPostagens(IList<Postagem> postagems)
        {
            Entidade.Postagens = postagems;
            return this;
        }

        public ConstrutorUsuario NovaPostagem(Postagem postagem)
        {
            Entidade.Postagens.Add(postagem);
            return this;
        }

        public ConstrutorUsuario ComComentarios(IList<Comentario> comentarios)
        {
            Entidade.Comentarios = comentarios;
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
            Entidade.Descricao = descricao;
            return this;
        }
        #endregion

        public Usuario Montar(Usuario usuario) => CriadoEm(DateTime.UtcNow)
                                                    .ComLogin(usuario.Login)
                                                    .ComEmail(usuario.Email)
                                                    .ComSenha(usuario.Senha, usuario is default(Usuario))
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
