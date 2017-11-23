using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Country
{
    public class CountryIsNameValidLength : ISpecification<Entities.Country>
    {
        const int NAME_MAX_LENGTH = 70;

        public bool IsSatisfiedBy(Entities.Country country)
        {
            if (country.Name == null)
                return true;

            return country.Name.Length <= NAME_MAX_LENGTH;
        }
    }
}
