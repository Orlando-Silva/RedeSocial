#region --Using--
using Core.Repositórios;
using System;
#endregion

namespace Core
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IComentarioRepositorio Comentarios { get; }
        IFotoDePerfilRepositorio FotosDePerfil { get; }
        IPostagemRepositorio Postagens { get; }
        IUsuarioRepositorio Usuarios { get; }
        void Encerrar();
    }
}
