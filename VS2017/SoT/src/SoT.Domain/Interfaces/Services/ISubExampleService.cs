using SoT.Domain.Entities.Example;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Services
{
    public interface ISubExampleService : IBaseService<SubExample>
    {
        IEnumerable<SubExample> Find(Expression<Func<SubExample, bool>> predicate);

        new ValidationResult Add(SubExample subExample);

        new ValidationResult Update(SubExample subExample);
    }
}
