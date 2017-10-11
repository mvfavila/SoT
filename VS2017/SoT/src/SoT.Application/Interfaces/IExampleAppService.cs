using SoT.Application.ViewModels;
using SoT.Domain.Entities.Example;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Application.Interfaces
{
    public interface IExampleAppService : IDisposable
    {
        IEnumerable<Example> GetActive();

        // TODO: paging should be added to method.
        IEnumerable<Example> GetAll();

        IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate);

        Example GetById(Guid id);

        void Add(ExampleSubExampleViewModel exampleSubExampleViewModel);

        void Update(Example example);

        void Delete(Guid id);
    }
}
