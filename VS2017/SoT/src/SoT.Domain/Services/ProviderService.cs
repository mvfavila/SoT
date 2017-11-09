using System;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;

namespace SoT.Domain.Services
{
    public class ProviderService : BaseService<Provider>, IProviderService
    {
        private readonly IProviderRepository providerRepository;
        private readonly IProviderReadOnlyRepository providerReadOnlyRepository;

        public ProviderService(IProviderRepository providerRepository,
            IProviderReadOnlyRepository providerReadOnlyRepository)
            : base(providerRepository, providerReadOnlyRepository)
        {
            this.providerRepository = providerRepository;
            this.providerReadOnlyRepository = providerReadOnlyRepository;
        }

        ValidationResult IProviderService.Add(Provider provider)
        {
            throw new NotImplementedException();
        }

        ValidationResult IProviderService.Update(Provider provider)
        {
            throw new NotImplementedException();
        }
    }
}
