using SoT.Domain.Entities.Example;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Services
{
    public interface ISubExampleService : IDisposable
    {
        IEnumerable<SubExample> GetAll();

        IEnumerable<SubExample> Find(Expression<Func<SubExample, bool>> predicate);

        SubExample GetById(Guid id);

        void Add(SubExample subExample);

        void Update(SubExample subExample);

        void Delete(Guid id);
    }
}
