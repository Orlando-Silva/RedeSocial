#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.ViewModels
{
    public  class HomeViewModel
    {
        #region --Atributos--
        public Usuario Usuario { get; set; }
        public Postagem NovaPostagem { get; set; }
        public List<Postagem> Postagens { get; set; }
        public Comentario Comentario { get; set; }
        #endregion

        #region --Construtores--
        public HomeViewModel()
        {

        }

        public HomeViewModel(Usuario usuario, List<Postagem> postagens)
        {
            Usuario = usuario;
            Postagens = postagens;
        }
        #endregion
    }
}
