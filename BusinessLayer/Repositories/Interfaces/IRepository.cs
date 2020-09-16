using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetRangeByParams(Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int skip = 0,
            int take = 10,
            bool disableTracking = true);

        int GetCountByParams(Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null);

        void Add(T entity);

        void Delete(int entityId);

        void Update(T entity);
    }
}
