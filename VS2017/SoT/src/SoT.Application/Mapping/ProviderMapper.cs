using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    public static class ProviderMapper
    {
        // EmployeeProviderViewModel

        internal static Provider FromViewModelToDomain(
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            return Provider.FactoryMap(
                employeeProviderViewModel.Id,
                employeeProviderViewModel.CompanyName,
                new List<Adventure>(),
                new List<Employee>(),
                employeeProviderViewModel.Active,
                employeeProviderViewModel.RegisterDate
                );
        }
    }
}
