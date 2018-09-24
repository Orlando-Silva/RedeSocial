#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.ViewModels
{
    public class PerfilViewModel
    {
        public Usuario Usuario { get; set; }

        public List<Postagem> Postagens { get; set; }

        public List<Usuario> Amigos { get; set; }

        public Usuario UsuarioEdicao { get; set; }

        public bool PodeEditar { get; set; }

        public string PasseEncriptado { get; set; }

        public PerfilViewModel()
        {

        }

        public PerfilViewModel(Usuario usuario, List<Postagem> postagens, List<Usuario> amigos, Usuario usuarioEdicao, bool podeEditar, string passeEncriptado)
        {
            Usuario = usuario;
            Postagens = postagens;
            Amigos = amigos;
            UsuarioEdicao = usuarioEdicao;
            PodeEditar = podeEditar;
            PasseEncriptado = passeEncriptado;
        }
    }
}
