#region --Using--
using Core.Entidades;
using Core.Enums;
using Services.Construtores.Core;
using System;
#endregion

namespace Services.Construtores
{
    public class ConstrutorAmizade : Construtor<Amizades>
    {
        public ConstrutorAmizade()
        {
        }

        public ConstrutorAmizade(Amizades _entity) : base(_entity)
        {
        }

        public ConstrutorAmizade ComSolicitante(int solicitanteID)
        {
            Entidade.SolicitanteID = solicitanteID;
            return this;
        }

        public ConstrutorAmizade ComConvidado(int convidadoID)
        {
            Entidade.ConvidadoID = convidadoID;
            return this;
        }

        public ConstrutorAmizade ComStatus(Status status)
        {
            Entidade.Status = status;
            return this;
        }

        public ConstrutorAmizade CriadoEm(DateTime data)
        {
            Entidade.Criado = data;
            return this;
        }

        public Amizades Montar(int solicitanteID, int convidadoID) => ComSolicitante(solicitanteID)
                                                                            .ComConvidado(convidadoID)
                                                                            .ComStatus(Status.Ativo)
                                                                            .CriadoEm(DateTime.UtcNow);
    }
}
