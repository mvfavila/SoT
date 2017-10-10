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

        public BaseRepository()
        {
            SoTContext = new SoTContext();
            DbSet = SoTContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);

            SoTContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Update(TEntity obj)
        {
            var entry = SoTContext.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            SoTContext.SaveChanges();
        }

        public void Dispose()
        {
            SoTContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
