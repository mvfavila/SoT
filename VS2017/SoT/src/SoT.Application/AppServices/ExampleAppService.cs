using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class ExampleAppService : BaseAppService<SoTContext>, IExampleAppService
    {
        private readonly IExampleService exampleService;
        private readonly ISubExampleService subExampleService;

        public ExampleAppService(
            IExampleService exampleService,
            ISubExampleService subExampleService)
        {
            this.exampleService = exampleService;
            this.subExampleService = subExampleService;
        }

        public ValidationAppResult Add(ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            var example = Mapping.Example.ExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            BeginTransaction();

            var result = exampleService.Add(example);
            if (!result.IsValid)
                return FromDomainToApplicationResult(result);

            // TODO: log should me added here informing that the example was added
                        
            var subExample = Mapping.Example.SubExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel);

            subExampleService.Add(subExample);

            Commit();

            return FromDomainToApplicationResult(result);
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
