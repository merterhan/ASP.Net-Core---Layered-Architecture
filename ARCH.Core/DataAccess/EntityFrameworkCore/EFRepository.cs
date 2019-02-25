using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARCH.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ARCH.Core.DataAccess.EntityFrameworkCore
{
    public class EFRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;

                context.SaveChanges();
            }  
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
            
        }

        public void Update(TEntity entity)
        {
            using (var context = new  TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
