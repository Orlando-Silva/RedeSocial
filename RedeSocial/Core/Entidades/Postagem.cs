#region --Using--
using Core.Enums;
using System;
#endregion

namespace Core.Entidades
{
    public class Postagem
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime Criado { get; set; }
        public DateTime? Modificado { get; set; }
        public Status Status { get; set; }
        public Usuario Autor { get; set; }
    }
}
