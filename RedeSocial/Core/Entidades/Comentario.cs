#region --Using--
using System;
#endregion

namespace Core.Entidades
{
    public class Comentario
    {
        public int ID { get; set; }
        public string Conteudo { get; set; }
        public DateTime Criado { get; set; }
        public Postagem Postagem { get; set; }
        public Usuario Autor { get; set; }
    }
}
