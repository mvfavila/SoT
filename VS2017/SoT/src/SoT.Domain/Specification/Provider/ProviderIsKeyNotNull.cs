using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Provider
{
    public class ProviderIsKeyNotNull : ISpecification<Entities.Provider>
    {
        public bool IsSatisfiedBy(Entities.Provider provider)
        {
            return provider.ProviderId != Guid.Empty;
        }
    }
}
