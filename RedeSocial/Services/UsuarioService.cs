﻿#region --Using--
using Core.Entidades;
using DAL;
using Helpers;
using Helpers.Interfaces;
using Services.Construtores;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;
#endregion

namespace Services
{
    public class UsuarioService : Service, IUsuarioService<Usuario>, IValidadorDeSessao<Usuario>
    {

        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public UsuarioService()
        {

        }
        #endregion

        #region --Login--
        public Usuario BuscarNaSessao(HttpSessionStateBase sessao) => SessionHelper.BuscarNaSessao(sessao, this);

        public bool ValidarSessao(Usuario entidade) => BuscarUnidadeDeTrabalho().Usuarios.Existe(entidade);

        public void FinalizarSessao(HttpSessionStateBase sessao) => throw new NotImplementedException();

        public void IniciarSessao(HttpSessionStateBase sessao, Usuario usuario)
        {
            usuario = UnidadeDeTrabalho.Usuarios.BuscarPorLoginSenha(usuario.Login, usuario.Senha) ?? throw new Exception($"Login ou senha incorretos.");
            SessionHelper.AdicionarNaSessao(sessao, usuario);
        }
        #endregion

        #region --Operações Básicas--
        public Usuario BuscarPorID(int ID) => UnidadeDeTrabalho.Usuarios.Buscar(ID);

        public Usuario Adicionar(Usuario _usuario)
        {
            var usuario = new ConstrutorUsuario().Montar(_usuario, true);
            UnidadeDeTrabalho.Usuarios.Adicionar(usuario);
            UnidadeDeTrabalho.Encerrar();
            return usuario;
        }

        public Usuario Atualizar(Usuario usuarioAtualizado)
        {
            var usuarioAntigo = UnidadeDeTrabalho.Usuarios.Buscar(usuarioAtualizado.ID);
            usuarioAntigo = new ConstrutorUsuario(usuarioAntigo).Montar(usuarioAtualizado, false);
            UnidadeDeTrabalho.Encerrar();
            return usuarioAtualizado;
        }

        public Usuario Inativar(int usuarioID)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> BuscarPorNome(string nome)
        {
            var usuarios = UnidadeDeTrabalho.Usuarios.BuscarPorNome(nome);
            return usuarios;
        }
        #endregion
    }
}
