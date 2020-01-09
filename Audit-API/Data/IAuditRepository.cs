using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Audit_API.Helpers;
using Audit_API.Models;

namespace Audit_API.Data
{
    public interface IAuditRepository<T> where T : class
    {
        T FindById(object id);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);

        void RemoveMultiple(List<T> entities);

        IQueryable<T> GetAll();

        Task<bool> SaveAll();

    }
}