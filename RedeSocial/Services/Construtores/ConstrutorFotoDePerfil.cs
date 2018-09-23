#region --Using--
using Core.Entidades;
using Core.Enums;
using Helpers;
using Services.Construtores.Core;
using System;
using System.Web;
#endregion

namespace Services.Construtores
{
    public class ConstrutorFotoDePerfil : Construtor<FotoDePerfil>
    {
        #region --Construtores--
        public ConstrutorFotoDePerfil()
        {
        }

        public ConstrutorFotoDePerfil(FotoDePerfil _entity) : base(_entity)
        {
        }
        #endregion

        #region --Construtores de Atributos--
        public ConstrutorFotoDePerfil ComNome(string nome)
        {
            Entidade.Nome = nome;
            return this;
        }

        public ConstrutorFotoDePerfil ComExtensao(string extensao)
        {
            Entidade.Extensao = extensao;
            return this;
        }

        public ConstrutorFotoDePerfil ComTamanho(decimal tamanho)
        {
            Entidade.Tamanho = tamanho;
            return this;
        }

        public ConstrutorFotoDePerfil ComCaminho(string caminho)
        {
            Entidade.Caminho = caminho;
            return this;
        }

        public ConstrutorFotoDePerfil ComHash(string hash)
        {
            Entidade.Hash = hash;
            return this;
        }

        public ConstrutorFotoDePerfil ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public ConstrutorFotoDePerfil ComUsuario(int usuarioID)
        {
            Entidade.UsuarioID = usuarioID;
            return this;
        }
        #endregion

        public FotoDePerfil Montar(HttpPostedFileBase arquivo, int usuarioID,string diretorio)
        {
            var hash = Seguranca.GerarHash(arquivo.FileName);

            return ComHash(hash)
                    .ComNome($"{ hash } - { arquivo.FileName }")
                    .ComStatus(Status.Ativo)
                    .ComTamanho(arquivo.ContentLength)
                    .ComExtensao(arquivo.ContentType)
                    .ComUsuario(usuarioID)
                    .ComCaminho($"{ diretorio }\\{ Entidade.Nome }");

        }

    }
}
