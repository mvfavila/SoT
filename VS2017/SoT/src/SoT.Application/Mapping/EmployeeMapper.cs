using SoT.Application.ViewModels;
using SoT.Domain.Entities;

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
                employeeProviderViewModel.EmployeeId,
                employeeProviderViewModel.BirthDate,
                employeeProviderViewModel.GenderId,
                provider,
                employeeProviderViewModel.UserId
                );
        }
    }
}
