using System;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Services
{
    public class ProviderService : IProviderService
    {
        public ValidationResult Add(Provider provider)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Provider GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Provider provider)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
