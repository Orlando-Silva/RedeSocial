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
        public List<Usuario> Usuarios { get; set; }
        public List<Amizades> AmizadesUsuarioLogado { get; set; }
        public Usuario UsuarioLogado { get; set; }
    }
}