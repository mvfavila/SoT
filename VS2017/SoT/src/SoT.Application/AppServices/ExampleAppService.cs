using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class ExampleAppService : IExampleAppService
    {
        private IExampleRepository exampleRepository;
        private ISubExampleRepository subExampleRepository;

        public ExampleAppService(
            IExampleRepository exampleRepository,
            ISubExampleRepository subExampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public void Add(ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            exampleRepository.Add(example);
                        
            var subExample = Mapping.Example.SubExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            subExampleRepository.Add(subExample);
        }
                                                                          
        public void Delete(Guid id)
        {
            exampleRepository.Delete(id);
        }

        public IEnumerable<ExampleViewModel> GetActive()
        {
            var example = exampleRepository.GetActive();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public IEnumerable<ExampleViewModel> GetAll()
        {
            var examples = exampleRepository.GetAll();

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(examples);
        }

        public ExampleViewModel GetById(Guid id)
        {
            var example = exampleRepository.GetById(id);

            return Mapping.Example.ExampleMapper.FromDomainToViewModel(example);
        }

        public void Update(ExampleViewModel exampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleViewModel);

            exampleRepository.Update(example);
        }

        public void Dispose()
        {
            exampleRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
