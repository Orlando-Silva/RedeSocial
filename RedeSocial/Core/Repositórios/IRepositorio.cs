#region --Using--
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Core.Repositórios
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T entidade);
        void Adicionar(IEnumerable<T> entidades);

        void Remover(T entidade);
        void Remover(IEnumerable<T> entidades);

        T Buscar(int ID);
        T Buscar(Expression<Func<T, bool>> predicato);
        IEnumerable<T> BuscarTodos();
        IEnumerable<T> BuscarTodos(Expression<Func<T, bool>> predicato);
    }
}
