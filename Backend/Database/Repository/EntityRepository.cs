using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Northwind.Database.Repository
{
    public class EntityRepository<T> : IRepository<T>
         where T : class
    {
        public NorthwindContext Context { get; private set; }

        protected DbSet<T> Set => Context.Set<T>();

        public EntityRepository(NorthwindContext db_dbContext)
        {
            Context = db_dbContext;
        }

        public IQueryable<T> Query => Set;

        public T Selecionar(Expression<Func<T, bool>> predicate)
        {
            return Context
                    .Set<T>()
                    .AsNoTracking()
                    .SingleOrDefault(predicate);
        }

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query)
                    .AsNoTracking()
                    .ToList();
            }
            else
            {
                return query
                    .AsNoTracking()
                    .ToList();
            }
        }

    }
}
