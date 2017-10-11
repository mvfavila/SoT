using SoT.Domain.Entities.Example;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Services
{
    public interface IExampleService : IDisposable
    {
        IEnumerable<Example> GetActive();

        IEnumerable<Example> GetAll();

        IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate);

        Example GetById(Guid id);

        void Add(Example example);

        void Update(Example example);

        void Delete(Guid id);
    }
}
