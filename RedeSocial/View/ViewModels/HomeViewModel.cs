#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.ViewModels
{
    public  class HomeViewModel
    {
        public Usuario Usuario { get; set; }
        public FotoDePerfil FotoDePerfil { get; set; }
        public Postagem NovaPostagem { get; set; }
        public List<Postagem> Postagens { get; set; }
    }
}
