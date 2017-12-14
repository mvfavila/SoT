using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    public static class MenuMapper
    {
        // MenuItemViewModel

        internal static MenuItemViewModel FromDomainToViewModel(MenuItem menuItem)
        {
            return new MenuItemViewModel
            {
                Name = menuItem.Name,
                ActionName = menuItem.ActionName,
                ControllerName = menuItem.ControllerName,
                Url = menuItem.Url,
                ClaimType = menuItem.ClaimType,
                ClaimValue = menuItem.ClaimValue
            };
        }

        internal static IEnumerable<MenuItemViewModel> FromDomainToViewModel(IEnumerable<MenuItem> menu)
        {
            var viewModels = new List<MenuItemViewModel>();

            foreach (var menuItem in menu)
            {
                viewModels.Add(FromDomainToViewModel(menuItem));
            }

            return viewModels;
        }
    }
}
