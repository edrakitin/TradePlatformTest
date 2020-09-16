using BusinessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Repositories.Realizations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(int entityId)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entityId);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<T> GetRangeByParams(
            Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int skip = 0, 
            int take = 10,
            bool disableTracking = true)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.Select(selector).Skip(skip).Take(take).AsEnumerable<T>();
        }

        public int GetCountByParams(Expression<Func<T, T>> selector,
            Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }


            return query.Select(selector).Count();
        }

        public void Update(T entity)
        {            
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
