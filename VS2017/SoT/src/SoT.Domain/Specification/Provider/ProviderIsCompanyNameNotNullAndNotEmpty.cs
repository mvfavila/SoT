using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Provider
{
    public class ProviderIsCompanyNameNotNullAndNotEmpty : ISpecification<Entities.Provider>
    {
        public bool IsSatisfiedBy(Entities.Provider provider)
        {
            return !string.IsNullOrEmpty(provider.CompanyName) && !string.IsNullOrWhiteSpace(provider.CompanyName);
        }
    }
}
