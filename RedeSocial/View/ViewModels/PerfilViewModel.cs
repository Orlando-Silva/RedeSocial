#region --Using--
using Core.Entidades;
#endregion

namespace Core.ViewModels
{
    public class PerfilViewModel
    {
        public Usuario Usuario { get; set; }

        public FotoDePerfil FotoDePerfil { get; set; }

        public Usuario UsuarioEdicao { get; set; }

        public bool PodeEditar { get; set; }

        public string FU_pass { get; set; }
    }
}
