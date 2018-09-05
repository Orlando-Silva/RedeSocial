#region --Using--
using Core.Repositórios;
using System;
#endregion

namespace Core
{
    /// <summary>
    ///     Interface que define o comportamento do intermediário entre as transações do framework de persistência e a aplicação.
    /// </summary>
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IComentarioRepositorio Comentarios { get; }

        IFotoDePerfilRepositorio FotosDePerfil { get; }

        IPostagemRepositorio Postagens { get; }

        IUsuarioRepositorio Usuarios { get; }

        void Encerrar();
    }
}
