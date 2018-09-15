#region --Using--
using Core.Enums;
using System;
#endregion

namespace Core.Entidades
{
    public class Comentario
    {
        public int ID { get; set; }

        public string Conteudo { get; set; }

        public Status Status { get; set; }

        public DateTime Criado { get; set; }

        public Postagem Postagem { get; set; }

        public int PostagemID { get; set; }

        public Usuario Autor { get; set; }

        public int AutorID { get; set; }
    }
}
