using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARCH.Core.Entities;

namespace ARCH.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        //IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);

        //IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> filter = null);

        List<T> GetListAsNoTracking(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Guid id);
    }
}
