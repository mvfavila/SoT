using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.Data.Repositories;
using System;
using System.Collections.Generic;

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

        public IEnumerable<ExampleViewModel> GetActive()
        {
            var example = Db.GetActive();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public IEnumerable<ExampleViewModel> GetAll()
        {
            var examples = Db.GetAll();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(examples);
        }

        public ExampleViewModel GetById(Guid id)
        {
            var example = Db.GetById(id);

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public void Update(ExampleViewModel exampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleViewModel);

            Db.Update(example);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
