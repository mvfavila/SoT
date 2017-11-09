using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using SoT.Infra.Data.Context;
using System;
using System.Transactions;

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

            ValidationResult result;

            using(var scope = new TransactionScope())
            {
                result = employeeService.Add(employee);

                if (!result.IsValid)
                    return FromDomainToApplicationResult(result);

                // TODO: log should be added here informing that the example was added

                result = providerService.Add(provider);

                if (!result.IsValid)
                    return FromDomainToApplicationResult(result);

                scope.Complete();
            }

            return FromDomainToApplicationResult(result);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public EmployeeProviderViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationAppResult Update(EmployeeProviderViewModel employeeProviderViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            employeeService.Dispose();
            providerService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
