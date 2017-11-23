using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Employee
{
    public class EmployeeIsKeyNotNull : ISpecification<Entities.Employee>
    {
        public bool IsSatisfiedBy(Entities.Employee employee)
        {
            return employee.EmployeeId != Guid.Empty;
        }
    }
}
