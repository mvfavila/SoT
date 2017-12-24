using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.Identity;
using System;
using System.Collections.Generic;

namespace SoT.Presentation.UI.MVC.Mapping
{
    public static class UserMapper
    {
        // UserEmployeeProviderViewModel

        internal static UserEmployeeProviderViewModel FromIdentityToViewModel(ApplicationUser user)
        {
            return new UserEmployeeProviderViewModel
            {
                UserId = Guid.Parse(user.Id),
                UserName = user.UserName,
                Name = user.Name,
                Lastname = user.Lastname
            };
        }

        internal static IEnumerable<UserEmployeeProviderViewModel> FromIdentityToViewModel(
            IEnumerable<ApplicationUser> users)
        {
            var viewModels = new List<UserEmployeeProviderViewModel>();
            foreach (var user in users)
            {
                viewModels.Add(FromIdentityToViewModel(user));
            }

            return viewModels;
        }
    }
}