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

        public static SubExample FromViewModelToDomain(SubExampleViewModel subExampleViewModel)
        {
            return new SubExample
            {
                SubExampleId = subExampleViewModel.SubExampleId,
                StringPropertyName = subExampleViewModel.StringPropertyName,
                SubExampleDatePropertyName = subExampleViewModel.SubExampleDatePropertyName,
                ExampleId = subExampleViewModel.ExampleId
            };
        }
    }
}
