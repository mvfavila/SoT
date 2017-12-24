using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Employee
{
    public class EmployeeIsGenderNotNull : ISpecification<Entities.Employee>
    {
        public bool IsSatisfiedBy(Entities.Employee employee)
        {
            return employee.GenderId != Guid.Empty;
        }
    }
}
