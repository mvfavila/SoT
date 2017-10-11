using SoT.Application.ViewModels;
using SoT.Domain.Entities.Example;

namespace SoT.Application.Mapping.Example
{
    public static class SubExampleMapper
    {
        public static SubExample FromViewModelToDomain(ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            return new SubExample
            {
                SubExampleId = exampleSubExampleViewModel.SubExampleId,
                StringPropertyName = exampleSubExampleViewModel.StringPropertyName,
                SubExampleDatePropertyName = exampleSubExampleViewModel.SubExampleDatePropertyName,
                ExampleId = exampleSubExampleViewModel.ExampleId
            };
        }
    }
}
