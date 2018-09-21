#region --Using--
using Core.Entidades;
using Core.Enums;
using Core.ViewModels;
using System;
using System.Collections.Generic;
#endregion

namespace Services.UsuarioServices.Módulos.Interfaces
{
    public interface IUsuarioConstrutorService<T> where T : Usuario
    {
        #region --Dados da Conta--
        IUsuarioConstrutorService<T> ComSenha(string senha);

        IUsuarioConstrutorService<T> ComEmail(string email);

        IUsuarioConstrutorService<T> ComLogin(string login);

        IUsuarioConstrutorService<T> CriadoEm(DateTime criado);

        IUsuarioConstrutorService<T> ComStatus(Status status);
        #endregion

        #region --Dados Pessoais--
        IUsuarioConstrutorService<T> ComNome(string nome);

        IUsuarioConstrutorService<T> ComTelefone(string telefone);

        IUsuarioConstrutorService<T> NasceuEm(DateTime dataDeNascimento);

        IUsuarioConstrutorService<T> NoEndereco(string endereco);

        IUsuarioConstrutorService<T> NaCidade(string cidade);

        IUsuarioConstrutorService<T> NoEstado(string estado);

        IUsuarioConstrutorService<T> NoPais(string pais);

        IUsuarioConstrutorService<T> ComComplemento(string complemento);

        IUsuarioConstrutorService<T> ComDescricao(string descricao);
        #endregion

        #region --Relacionamentos--
        IUsuarioConstrutorService<T> ComComentarios(IList<Comentario> comentarios);

        IUsuarioConstrutorService<T> ComFotos(IList<FotoDePerfil> fotos);

        IUsuarioConstrutorService<T> ComPostagens(IList<Postagem> postagems);

        IUsuarioConstrutorService<T> NovoComentario(Comentario comentario);

        IUsuarioConstrutorService<T> NovaFoto(FotoDePerfil foto);

        IUsuarioConstrutorService<T> NovaPostagem(Postagem postagem);
        #endregion

        T Montar(NovoUsuarioViewModel novoUsuarioViewModel);
    }
}
