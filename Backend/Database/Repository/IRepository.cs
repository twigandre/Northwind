using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Northwind.Database.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        void Salvar(T entity);

        void Update(T entity);

        void Apagar(T entity);

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        public T Selecionar(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query { get; }

        NorthwindContext Context { get; }
    }
}
