using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System;

namespace SoT.Application.Mapping
{
    public static class EmployeeMapper
    {
        // EmployeeProviderViewModel

        internal static Employee FromViewModelToDomain(
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            var provider = ProviderMapper.FromViewModelToDomain(employeeProviderViewModel);

            return Employee.FactoryMap(
                Guid.Parse(employeeProviderViewModel.Id),
                employeeProviderViewModel.Name,
                employeeProviderViewModel.Surname,
                employeeProviderViewModel.Email,
                employeeProviderViewModel.BirthDate,
                provider
                );
        }
    }
}
