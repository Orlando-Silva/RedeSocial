#region --Using--
using Core.Repositórios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
#endregion

namespace DAL.Repositórios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        #region --Atributos--
        protected DbContext Contexto { get; private set; }

        protected DbSet<T> Entidades { get; private set; }
        #endregion

        #region --Construtor--
        public Repositorio(DbContext _contexto)
        {
            Contexto = _contexto;
            Entidades = _contexto.Set<T>();
        }
        #endregion

        public void Adicionar(T entidade) => Entidades.Add(entidade);

        public void Adicionar(IEnumerable<T> entidades) => Entidades.AddRange(entidades);

        public T Buscar(int ID) => Entidades.Find(ID);

        public T Buscar(Expression<Func<T, bool>> predicato) => Entidades.FirstOrDefault(predicato);

        public IEnumerable<T> BuscarTodos() => Entidades.ToList();

        public IEnumerable<T> BuscarTodos(Expression<Func<T, bool>> predicato) => Entidades.Where(predicato);

        public void Remover(T entidade) => Entidades.Remove(entidade);

        public void Remover(IEnumerable<T> entidades) => Entidades.RemoveRange(entidades);
    }
}
