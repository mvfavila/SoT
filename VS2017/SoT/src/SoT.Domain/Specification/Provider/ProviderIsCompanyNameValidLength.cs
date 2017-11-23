using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Provider
{
    class ProviderIsCompanyNameValidLength : ISpecification<Entities.Provider>
    {
        const int NAME_MAX_LENGTH = 400;

        public bool IsSatisfiedBy(Entities.Provider provider)
        {
            if (provider.CompanyName == null)
                return true;

            return provider.CompanyName.Length <= NAME_MAX_LENGTH;
        }
    }
}
