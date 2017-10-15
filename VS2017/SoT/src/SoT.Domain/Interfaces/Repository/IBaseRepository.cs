using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        // TODO: paging should be added to method.
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(Guid id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(Guid id);

        void SaveChanges();
    }
}
