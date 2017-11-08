using SoT.Application.Validation;
using SoT.Application.ViewModels;
using System;

namespace SoT.Application.Interfaces
{
    public interface IProviderAppService : IDisposable
    {
        EmployeeProviderViewModel GetById(Guid id);

        ValidationAppResult Add(EmployeeProviderViewModel employeeProviderViewModel);

        ValidationAppResult Update(EmployeeProviderViewModel employeeProviderViewModel);

        void Delete(Guid id);
    }
}
