using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Employee
{
    public class EmployeeIsProviderNotNull : ISpecification<Entities.Employee>
    {
        public bool IsSatisfiedBy(Entities.Employee employee)
        {
            return employee.ProviderId != Guid.Empty;
        }
    }
}
