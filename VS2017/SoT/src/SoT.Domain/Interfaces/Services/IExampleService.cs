using SoT.Domain.Entities.Example;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Services
{
    public interface IExampleService : IBaseService<Example>
    {
        IEnumerable<Example> GetActive();

        IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate);

        new ValidationResult Add(Example example);
    }
}
