using SoT.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SoT.Application.Mapping.Example
{
    public static class ExampleMapper
    {
        // ExampleSubExampleViewModel

        internal static Domain.Entities.Example.Example FromViewModelToDomain(
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

        internal static IEnumerable<Domain.Entities.Example.Example> FromViewModelToDomain(
            IEnumerable<ExampleSubExampleViewModel> exampleSubExampleViewModels)
        {
            var examples = new List<Domain.Entities.Example.Example>();

            foreach (var exampleSubExampleViewModel in exampleSubExampleViewModels)
            {
                examples.Add(FromViewModelToDomain(exampleSubExampleViewModel));
            }

            return examples;
        }

        // ExampleViewModel

        internal static Domain.Entities.Example.Example FromViewModelToDomain(
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

        internal static ExampleViewModel FromDomainToViewModel(
            Domain.Entities.Example.Example example)
        {
            return new ExampleViewModel
            {
                ExampleId = example.ExampleId,
                Name = example.Name,
                DatePropertyName = example.DatePropertyName,
                SubExamples = SubExampleMapper.FromDomainToViewModel(example.SubExamples),
                Active = example.Active,
                RegisterDate = example.RegisterDate
            };
        }

        internal static IEnumerable<ExampleViewModel> FromDomainToViewModel(
            IEnumerable<Domain.Entities.Example.Example> examples)
        {
            var exampleViewModels = new List<ExampleViewModel>();

            foreach (var example in examples)
            {
                exampleViewModels.Add(FromDomainToViewModel(example));
            }

            return exampleViewModels;
        }
    }
}
