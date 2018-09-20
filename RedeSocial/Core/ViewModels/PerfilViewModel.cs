#region --Using--
using Core.Entidades;
#endregion

namespace Core.ViewModels
{
    public class PerfilViewModel
    {
        public Usuario Usuario { get; set; }

        public bool PodeEditar { get; set; }
    }
}
