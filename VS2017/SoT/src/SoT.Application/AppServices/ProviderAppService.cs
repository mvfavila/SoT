using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;

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
            throw new NotImplementedException();
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
