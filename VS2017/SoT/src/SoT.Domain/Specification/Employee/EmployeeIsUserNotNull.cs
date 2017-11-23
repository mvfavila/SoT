using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Employee
{
    public class EmployeeIsUserNotNull : ISpecification<Entities.Employee>
    {
        public bool IsSatisfiedBy(Entities.Employee employee)
        {
            return employee.UserId != Guid.Empty;
        }
    }
}
