#region --Using--
using Core.Enums;
using System;
using System.Collections.Generic;
#endregion

namespace Core.Entidades
{
    public class Postagem
    {
        public int ID { get; set; }

        public string Corpo { get; set; }

        public Status Status { get; set; }

        public DateTime Criado { get; set; }

        public DateTime? Modificado { get; set; }

        public Usuario Autor { get; set; }

        public IList<Comentario> Comentarios { get; set; }
    }
}
