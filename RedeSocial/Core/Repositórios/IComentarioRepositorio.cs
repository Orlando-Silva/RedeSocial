﻿#region --Using--
using Core.Entidades;
using System.Collections.Generic;
#endregion

namespace Core.Repositórios
{
    public interface IComentarioRepositorio : IRepositorio<Comentario>
    {
        List<Comentario> BuscarPorPostagem(int postagemID);
    }
}
