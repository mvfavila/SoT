using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.City
{
    public class CityIsNameValidLength : ISpecification<Entities.City>
    {
        const int NAME_MAX_LENGTH = 100;

        public bool IsSatisfiedBy(Entities.City city)
        {
            if (city.Name == null)
                return true;

            return city.Name.Length <= NAME_MAX_LENGTH;
        }
    }
}
