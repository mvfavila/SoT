using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    public static class CategoryMapper
    {
        // CategoryViewModel

        internal static CategoryViewModel FromDomainToViewModel(
            Category category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Active = category.Active,
                ElementId = category.ElementId
            };
        }

        internal static IEnumerable<CategoryViewModel> FromDomainToViewModel(
            IEnumerable<Category> categories)
        {
            var viewModels = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                viewModels.Add(FromDomainToViewModel(category));
            }

            return viewModels;
        }
    }
}
