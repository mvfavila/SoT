using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Infra.Data.Context;
using System;

namespace SoT.Application.AppServices
{
    public class ProviderAppService : BaseAppService<SoTContext>, IProviderAppService
    {
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
