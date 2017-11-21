using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using System.Linq;

namespace SoT.Application.AppServices
{
    public class ProviderAppService : BaseAppService<SoTContext>, IProviderAppService
    {
        private readonly IEmployeeService employeeService;
        private readonly IProviderService providerService;

        public ProviderAppService(IEmployeeService employeeService, IProviderService providerService)
        {
            this.employeeService = employeeService;
            this.providerService = providerService;
        }

        public ValidationAppResult Add(EmployeeProviderViewModel employeeProviderViewModel)
        {
            var employee = Mapping.EmployeeMapper.FromViewModelToDomain(employeeProviderViewModel);

            var provider = Mapping.ProviderMapper.FromViewModelToDomain(employeeProviderViewModel);

            provider.AddEmployee(employee);

            var result = employeeService.Add(employee);

            // TODO: log should be added here informing that the example was added
            // TODO: check if it was a valid insertion

            Commit();

            return FromDomainToApplicationResult(result);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public EmployeeProviderViewModel GetByUserId(Guid userId)
        {
            var provider = providerService.GetWithEmployeeById(userId);

            return Mapping.ProviderMapper.FromDomainToViewModel(provider);
        }

        public ValidationAppResult Update(EmployeeProviderViewModel employeeProviderViewModel)
        {
            var employee = Mapping.EmployeeMapper.FromViewModelToDomain(employeeProviderViewModel);

            var provider = Mapping.ProviderMapper.FromViewModelToDomain(employeeProviderViewModel);

            provider.AddEmployee(employee);

            var result = employeeService.Update(employee);

            Commit();

            return FromDomainToApplicationResult(result);
        }

        public void Dispose()
        {
            employeeService.Dispose();
            providerService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
