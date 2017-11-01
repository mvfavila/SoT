using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SoT.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : IDbContext, new()
    {
        protected IDbSet<TEntity> DbSet;
        protected readonly IDbContext context;

        // TODO: contextManager must be initialized here
        private readonly ContextManager contextManager;

        public BaseRepository()
        {
            contextManager = new ContextManager();
            context = contextManager.GetContext();
            DbSet = context.Set<TEntity>();
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

        /// <summary>
        /// Finds an entity with the given primary key values.<br/>
        /// If an entity with the given primary key values exists in the context, then it is returned immediately<br/>
        /// without making a request to the store. Otherwise, a request is made to the store for an entity with<br/>
        /// the given primary key values and this entity, if found, is attached to the context and returned.<br/>
        /// If no entity is found in the context or the store, then null is returned.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>Entity instance.</returns>
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            var entry = context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
