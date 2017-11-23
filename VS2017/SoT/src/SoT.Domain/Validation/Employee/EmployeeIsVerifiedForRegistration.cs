using SoT.Domain.Specification.Employee;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Employee
{
    public class EmployeeIsVerifiedForRegistration : BaseSupervisor<Entities.Employee>
    {
        public EmployeeIsVerifiedForRegistration()
        {
            var isKeyNotNull = new EmployeeIsKeyNotNull();
            var isEmployeeOlderThan18 = new EmployeeIsEmployeeOlderThan18();
            var isProviderNotNull = new EmployeeIsProviderNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Employee>(isKeyNotNull,
                $"{nameof(Entities.Employee.EmployeeId)} is required"));
            base.AddRule("IsEmployeeOlderThan18", new Rule<Entities.Employee>(isEmployeeOlderThan18,
                $"To register as an {nameof(Entities.Employee)} must be over 18 years of age"));
            base.AddRule("IsProviderNotNull", new Rule<Entities.Employee>(isProviderNotNull,
                $"{nameof(Entities.Employee.Provider)} is required"));
        }
    }
}
