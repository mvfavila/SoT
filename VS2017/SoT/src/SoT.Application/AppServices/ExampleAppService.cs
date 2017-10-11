using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Domain.Entities.Example;
using SoT.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Application.AppServices
{
    public class ExampleAppService : IExampleAppService
    {
        private ExampleRepository Db = new ExampleRepository();

        public void Add(ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            Db.Add(example);
                        
            var subExample = Mapping.Example.SubExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            new SubExampleRepository().Add(subExample);
        }
                                                                          
        public void Delete(Guid id)
        {
            Db.Delete(id);
        }

        public IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate)
        {
            return Db.Find(predicate);
        }

        public IEnumerable<Example> GetActive()
        {
            return Db.GetActive();
        }

        public IEnumerable<Example> GetAll()
        {
            return Db.GetAll();
        }

        public Example GetById(Guid id)
        {
            return Db.GetById(id);
        }

        public void Update(Example example)
        {
            Db.Update(example);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
