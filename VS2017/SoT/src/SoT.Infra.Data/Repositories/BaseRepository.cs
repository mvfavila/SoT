using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SoT.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected SoTContext SoTContext;
        protected DbSet<TEntity> DbSet;

        // TODO: contextManager must be initialized here
        private readonly ContextManager contextManager;

        public BaseRepository()
        {
            SoTContext = contextManager.GetContext();
            DbSet = SoTContext.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            var entry = SoTContext.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            SoTContext.SaveChanges();
        }

        public void Dispose()
        {
            SoTContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
