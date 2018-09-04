#region --Using--
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Core.Repositórios
{
    /// <summary>
    ///     Interface que define quais serão os métodos genéricos de transação entre o framework de persistência e a aplicação.
    /// </summary>
    /// <typeparam name="T">Entidade genérica que é a representação lógica de uma tabela no banco de dados.</typeparam>
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
