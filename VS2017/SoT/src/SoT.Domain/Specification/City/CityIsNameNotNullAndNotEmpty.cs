using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.City
{
    public class CityIsNameNotNullAndNotEmpty : ISpecification<Entities.City>
    {
        public bool IsSatisfiedBy(Entities.City city)
        {
            return !string.IsNullOrEmpty(city.Name) && !string.IsNullOrWhiteSpace(city.Name);
        }
    }
}
