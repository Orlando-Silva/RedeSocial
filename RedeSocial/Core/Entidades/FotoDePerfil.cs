#region --Using--
using Core.Enums;
#endregion

namespace Core.Entidades
{
    public class FotoDePerfil
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Extensao { get; set; }

        public decimal Tamanho { get; set; }

        public string Caminho { get; set; }

        public string Hash { get; set; }

        public Status Status { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioID { get; set; }
    }
}
