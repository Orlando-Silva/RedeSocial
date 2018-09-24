#region --Using--
using Core.Entidades;
using Core.Enums;
using Services.Construtores.Core;
using System;
#endregion

namespace Services.Construtores
{
    public class ConstrutorComentario : Construtor<Comentario>
    {
        #region --Construtores--
        public ConstrutorComentario()
        {
        }

        public ConstrutorComentario(Comentario _entity) : base(_entity)
        {
        }
        #endregion

        #region --Construtores de Atributos--
        public ConstrutorComentario ComConteudo(string conteudo)
        {
            Entidade.Conteudo = conteudo;
            return this;
        }

        public ConstrutorComentario ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public ConstrutorComentario CriadoEm(DateTime data)
        {
            Entidade.Criado = data;
            return this;
        }

        public ConstrutorComentario ComAutor(int autorID)
        {
            Entidade.AutorID = autorID;
            return this;
        }
        #endregion

        public Comentario Montar(string conteudo, int autorID) => ComStatus(Status.Ativo)
                                                                    .CriadoEm(DateTime.UtcNow)
                                                                    .ComConteudo(conteudo)
                                                                    .ComAutor(autorID);
    }
}
