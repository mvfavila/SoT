using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Employee
{
    public class EmployeeIsEmployeeOlderThan18 : ISpecification<Entities.Employee>
    {
        const int MINIMUM_AGE = 18;

        public bool IsSatisfiedBy(Entities.Employee employee)
        {
            var today = DateTime.Today;

            var age = today.Year - employee.BirthDate.Year;

            if (employee.BirthDate > today.AddYears(-age)) age--;

            return age >= MINIMUM_AGE;
        }
    }
}
