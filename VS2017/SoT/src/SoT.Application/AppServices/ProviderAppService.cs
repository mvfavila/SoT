using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.Data.Context;
using System;

namespace SoT.Application.AppServices
{
    public class ProviderAppService : BaseAppService<SoTContext>, IProviderAppService
    {
        private readonly IEmployeeService employeeService;
        private readonly IProviderService providerService;
        private readonly ApplicationUserManager userManager;

        public ProviderAppService(IEmployeeService employeeService, IProviderService providerService,
            ApplicationUserManager userManager)
        {
            this.employeeService = employeeService;
            this.providerService = providerService;
            this.userManager = userManager;
        }

        public ValidationAppResult Add(EmployeeProviderViewModel employeeProviderViewModel)
        {
            var employee = Mapping.EmployeeMapper.FromViewModelToDomain(employeeProviderViewModel);

            var provider = Mapping.ProviderMapper.FromViewModelToDomain(employeeProviderViewModel);

            BeginTransaction();

            var result = employeeService.Add(employee);

            if (!result.IsValid)
                return FromDomainToApplicationResult(result);

            result = providerService.Add(provider);

            if (!result.IsValid)
                return FromDomainToApplicationResult(result);

            // TODO: log should me added here informing that the example was added

            Commit();

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
            GC.SuppressFinalize(this);
        }
    }
}
