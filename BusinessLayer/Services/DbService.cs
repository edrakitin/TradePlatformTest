using BusinessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Services
{
     public class DbService<T> where T : class
    {
        private readonly IRepository<T> _repo;

        public DbService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public void Add(T entity)
        {
            _repo.Add(entity);

        }

        public void Delete(int entityId)
        {
            _repo.Delete(entityId);
        }

        public IEnumerable<T> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public IEnumerable<T> GetRangeByParams(Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int skip = 0,
            int take = 9,
            bool disableTracking = true)
        {
            return _repo.GetRangeByParams(selector, predicate, orderBy, include, skip, take, disableTracking);
        }

        public int GetCountByParams(Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null)
        {
            return _repo.GetCountByParams(selector, predicate);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }
    }
}
