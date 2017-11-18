using System;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Validation.Provider;

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

        public Provider GetWithEmployeeById(Guid userId)
        {
            return providerReadOnlyRepository.GetWithEmployeeById(userId);
        }

        ValidationResult IProviderService.Add(Provider provider)
        {
            var validationResult = new ValidationResult();

            if (!provider.IsValid())
            {
                validationResult.AddError(provider.ValidationResult);
                return validationResult;
            }

            var validator = new ProviderIsVerifiedForRegistration();
            var validationService = validator.Validate(provider);
            if (!validationService.IsValid)
            {
                validationResult.AddError(provider.ValidationResult);
                return validationResult;
            }

            providerRepository.Add(provider);

            return validationResult;
        }

        ValidationResult IProviderService.Update(Provider provider)
        {
            throw new NotImplementedException();
        }
    }
}
