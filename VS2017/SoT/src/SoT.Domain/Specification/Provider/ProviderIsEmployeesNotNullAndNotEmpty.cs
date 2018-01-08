using SoT.Domain.Interfaces.Specification;
using System.Linq;

namespace SoT.Domain.Specification.Provider
{
    class ProviderIsEmployeesNotNullAndNotEmpty : ISpecification<Entities.Provider>
    {
        public bool IsSatisfiedBy(Entities.Provider provider)
        {
            if (provider.Employees == null)
                return false;

            return provider.Employees.Any();
        }
    }
}
