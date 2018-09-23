#region --Using--
using Core.Entidades;
using Core.Enums;
using Services.Construtores.Core;
using System;
#endregion

namespace Services.Construtores
{
    public class ConstrutorPostagem : Construtor<Postagem>
    {
        #region --Construtores--
        public ConstrutorPostagem()
        {
        }

        public ConstrutorPostagem(Postagem _entity) : base(_entity)
        {
        }
        #endregion

        #region --Construtores De Atributos--
        public ConstrutorPostagem ComCorpo(string corpo)
        {
            Entidade.Corpo = corpo;
            return this;
        }

        public ConstrutorPostagem ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public ConstrutorPostagem CriadoEm(DateTime data)
        {
            Entidade.Criado = data;
            return this;
        }

        public ConstrutorPostagem ModificadoEm(DateTime data)
        {
            Entidade.Modificado = data;
            return this;
        }

        public ConstrutorPostagem ComAutor(int autorID)
        {
            Entidade.AutorID = autorID;
            return this;
        }

        public ConstrutorPostagem ComComentario(Comentario comentario)
        {
            Entidade.Comentarios.Add(comentario);
            return this;
        }
        #endregion

        public Postagem Montar(string corpo, int autorID) => ComCorpo(corpo)
                                                                .ComStatus(Status.Ativo)
                                                                .CriadoEm(DateTime.UtcNow)
                                                                .ComAutor(autorID);        
    }
}
