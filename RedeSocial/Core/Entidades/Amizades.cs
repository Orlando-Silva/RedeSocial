#region --Using--
using Core.Enums;
using System;
#endregion

namespace Core.Entidades
{
    public class Amizade
    {
        public int ID { get; set; }

        public Usuario Solicitante { get; set; }

        public int SolicitanteID { get; set; }

        public Usuario Convidado { get; set; }

        public int ConvidadoID { get; set; }

        public DateTime Criado { get; set; }

        public Status Status { get; set; }
    }
}
