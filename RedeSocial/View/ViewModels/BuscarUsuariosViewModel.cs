#region --Using--
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace View.ViewModels
{
    public class BuscarUsuariosViewModel
    {
        public List<Usuario> UsuariosEncontrados { get; set; }
        public List<Amizade> Amizades { get; set; }
        public Usuario Usuario { get; set; }

        public BuscarUsuariosViewModel(Usuario usuario, List<Usuario> usuariosEncontrados, List<Amizade> amizades)
        {
            Usuario = usuario;
            Amizades = amizades;
            UsuariosEncontrados = usuariosEncontrados;
        }
    }
}