using SoT.Application.Validation;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IProviderAppService : IDisposable
    {
        EmployeeProviderViewModel GetByUserId(Guid userId);

        IEnumerable<EmployeeProviderViewModel> GetAll();

        IEnumerable<UserEmployeeProviderViewModel> LoadUserData(
            IEnumerable<UserEmployeeProviderViewModel> userEmployeeProviderViewModels);

        ValidationAppResult Add(EmployeeProviderViewModel employeeProviderViewModel);

        ValidationAppResult Update(EmployeeProviderViewModel employeeProviderViewModel);

        void Delete(Guid id);
    }
}
