
using SoT.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SoT.Application.Mapping.Example
{
    public static class ExampleMapper
    {
        public static Domain.Entities.Example.Example FromViewModelToDomain(
            ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            return new Domain.Entities.Example.Example
            {
                ExampleId = exampleSubExampleViewModel.ExampleId,
                Name = exampleSubExampleViewModel.Name,
                DatePropertyName = exampleSubExampleViewModel.DatePropertyName,
                SubExamples = new List<Domain.Entities.Example.SubExample>
                {
                    SubExampleMapper.FromViewModelToDomain(exampleSubExampleViewModel)
                }
            };
        }

        public static Domain.Entities.Example.Example FromViewModelToDomain(
            ExampleViewModel exampleViewModel)
        {
            return new Domain.Entities.Example.Example
            {
                ExampleId = exampleViewModel.ExampleId,
                Name = exampleViewModel.Name,
                DatePropertyName = exampleViewModel.DatePropertyName,
                SubExamples = new List<Domain.Entities.Example.SubExample>
                {
                    SubExampleMapper.FromViewModelToDomain(exampleViewModel.SubExamples.First())
                }
            };
        }
    }
}
