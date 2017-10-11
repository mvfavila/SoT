
using SoT.Application.ViewModels;
using System.Collections.Generic;

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
    }
}
