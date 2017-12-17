using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    public static class GenderMapper
    {
        // GenderViewModel

        internal static GenderViewModel FromDomainToViewModel(Gender gender)
        {
            return new GenderViewModel
            {
                GenderId = gender.GenderId,
                Value = gender.Value,
                Active = gender.Active
            };
        }

        internal static IEnumerable<GenderViewModel> FromDomainToViewModel(IEnumerable<Gender> genders)
        {
            var viewModels = new List<GenderViewModel>();
            foreach (var gender in genders)
            {
                viewModels.Add(FromDomainToViewModel(gender));
            }

            return viewModels;
        }
    }
}
