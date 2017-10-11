using SoT.Application.ViewModels;
using SoT.Domain.Entities.Example;
using System.Collections.Generic;

namespace SoT.Application.Mapping.Example
{
    public static class SubExampleMapper
    {
        // ExampleSubExampleViewModel

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

        public static IEnumerable<SubExample> FromViewModelToDomain(
            IEnumerable<ExampleSubExampleViewModel> exampleSubExampleViewModels)
        {
            var viewModels = new List<SubExample>();

            foreach (var subExample in exampleSubExampleViewModels)
            {
                viewModels.Add(FromViewModelToDomain(subExample));
            }

            return viewModels;
        }

        // SubExampleViewModel

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

        public static IEnumerable<SubExample> FromViewModelToDomain(
            IEnumerable<SubExampleViewModel> subExampleViewModels)
        {
            var viewModels = new List<SubExample>();

            foreach (var subExample in subExampleViewModels)
            {
                viewModels.Add(FromViewModelToDomain(subExample));
            }

            return viewModels;
        }

        internal static SubExampleViewModel FromDomainToViewModel(SubExample subExample)
        {
            return new SubExampleViewModel
            {
                SubExampleId = subExample.SubExampleId,
                StringPropertyName = subExample.StringPropertyName,
                SubExampleDatePropertyName = subExample.SubExampleDatePropertyName,
                ExampleId = subExample.ExampleId,
                Example = ExampleMapper.FromDomainToViewModel(subExample.Example)
            };
        }

        internal static IEnumerable<SubExampleViewModel> FromDomainToViewModel(IEnumerable<SubExample> subExamples)
        {
            var viewModels = new List<SubExampleViewModel>();

            foreach (var subExample in subExamples)
            {
                viewModels.Add(FromDomainToViewModel(subExample));
            }

            return viewModels;
        }
    }
}
