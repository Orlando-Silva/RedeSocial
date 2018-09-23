#region --Using--
using Core.Entidades;
using Core.Enums;
using DAL;
using Services.Construtores;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Services
{
    public class AmizadeService : Service, IAmizadeService<Amizades>
    {
        #region --Atributos--
        private static UnidadeDeTrabalho UnidadeDeTrabalho { get { return BuscarUnidadeDeTrabalho(); } }
        #endregion

        #region --Construtor--
        public AmizadeService()
        {

        }
        #endregion

        public Amizades Adicionar(int solicitanteID, int convidadoID)
        {
            var amizadeExistente = Verificar(solicitanteID, convidadoID);

            if (amizadeExistente == null)
            {
                var amizade = new ConstrutorAmizade().Montar(solicitanteID, convidadoID);
                UnidadeDeTrabalho.Amizades.Adicionar(amizade);
                amizadeExistente = amizade;
            }
            else
            {
                Atualizar(amizadeExistente.ID, Status.Ativo);
            }

            UnidadeDeTrabalho.Encerrar();
            return amizadeExistente;
        }

        public Amizades Atualizar(int amizadeID, Status status)
        {
            var amizade = UnidadeDeTrabalho.Amizades.Buscar(amizadeID);
            if(amizade != null)
            {
                amizade = new ConstrutorAmizade(amizade).ComStatus(status);
                UnidadeDeTrabalho.Encerrar();
            }
            return amizade;
        }

        public List<Amizades> Buscar(int usuarioID, Status status) => UnidadeDeTrabalho.Amizades.BuscarTodos(_ => _.Solicitante.ID == usuarioID || _.Convidado.ID == usuarioID && _.Status == status).ToList();

        public List<Usuario> BuscarAmigos(int usuarioID, Status status) => UnidadeDeTrabalho.Amizades.BuscarAmigos(usuarioID, status);

        public Amizades Verificar(int solicitanteID, int convidadoID)
        {
            return UnidadeDeTrabalho.Amizades.Buscar(_ => _.Solicitante.ID == solicitanteID && _.Convidado.ID == convidadoID);
        }

        public Amizades Buscar(int solicitanteID, int convidadoID)
        {
            return UnidadeDeTrabalho.Amizades.Buscar(_ => _.Solicitante.ID == solicitanteID && _.Convidado.ID == convidadoID);
        }
    }
}
