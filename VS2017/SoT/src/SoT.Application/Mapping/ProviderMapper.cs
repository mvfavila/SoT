using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SoT.Application.Mapping
{
    public static class ProviderMapper
    {
        // EmployeeProviderViewModel

        internal static Provider FromViewModelToDomain(
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            if (employeeProviderViewModel == null)
                return null;

            return Provider.FactoryMap(
                employeeProviderViewModel.ProviderId,
                employeeProviderViewModel.CompanyName,
                new List<Adventure>(),
                new List<Employee>(),
                employeeProviderViewModel.Active,
                employeeProviderViewModel.RegisterDate
                );
        }

        internal static EmployeeProviderViewModel FromDomainToViewModel(Provider provider)
        {
            if (provider == null)
                return null;

            var employee = provider.Employees.FirstOrDefault();

            return new EmployeeProviderViewModel
            {
                EmployeeId = employee.EmployeeId,
                BirthDate = employee.BirthDate,
                GenderId = employee.GenderId,
                UserId = employee.UserId,
                ProviderId = provider.ProviderId,
                CompanyName = provider.CompanyName,
                Active = provider.Active,
                RegisterDate = provider.RegisterDate
            };
        }
    }
}
