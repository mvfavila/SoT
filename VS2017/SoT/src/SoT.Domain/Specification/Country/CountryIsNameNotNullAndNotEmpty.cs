using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Country
{
    public class CountryIsNameNotNullAndNotEmpty : ISpecification<Entities.Country>
    {
        public bool IsSatisfiedBy(Entities.Country country)
        {
            return !string.IsNullOrEmpty(country.Name) && !string.IsNullOrWhiteSpace(country.Name);
        }
    }
}
