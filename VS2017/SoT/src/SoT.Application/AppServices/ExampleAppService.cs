using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class ExampleAppService : IExampleAppService
    {
        private IExampleService exampleService;
        private ISubExampleRepository subExampleRepository;

        public ExampleAppService(
            IExampleService exampleService,
            ISubExampleRepository subExampleRepository)
        {
            this.exampleService = exampleService;
        }

        public void Add(ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            exampleService.Add(example);
                        
            var subExample = Mapping.Example.SubExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            subExampleRepository.Add(subExample);
        }
                                                                          
        public void Delete(Guid id)
        {
            exampleService.Delete(id);
        }

        public IEnumerable<ExampleViewModel> GetActive()
        {
            var example = exampleService.GetActive();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public IEnumerable<ExampleViewModel> GetAll()
        {
            var examples = exampleService.GetAll();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(examples);
        }

        public ExampleViewModel GetById(Guid id)
        {
            var example = exampleService.GetById(id);

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public void Update(ExampleViewModel exampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleViewModel);

            exampleService.Update(example);
        }

        public void Dispose()
        {
            exampleService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
