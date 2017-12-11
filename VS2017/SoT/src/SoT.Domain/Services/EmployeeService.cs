using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Validation.Employee;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeReadOnlyRepository employeeReadOnlyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IEmployeeReadOnlyRepository employeeReadOnlyRepository)
            : base(employeeRepository, employeeReadOnlyRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeReadOnlyRepository = employeeReadOnlyRepository;
        }

        public new ValidationResult Add(Employee employee)
        {
            var validationResult = new ValidationResult();

            if (!employee.IsValid())
            {
                validationResult.AddError(employee.ValidationResult);
                return validationResult;
            }

            var validator = new EmployeeIsVerifiedForRegistration();
            var validationService = validator.Validate(employee);
            if (!validationService.IsValid)
            {
                validationResult.AddError(employee.ValidationResult);
                return validationResult;
            }

            employeeRepository.Add(employee);

            return validationResult;
        }

        public new ValidationResult Update(Employee employee)
        {
            var validationResult = new ValidationResult();

            if (!employee.IsValid())
            {
                validationResult.AddError(employee.ValidationResult);
                return validationResult;
            }

            var validator = new EmployeeIsVerifiedForEdition();
            var validationService = validator.Validate(employee);
            if (!validationService.IsValid)
            {
                validationResult.AddError(employee.ValidationResult);
                return validationResult;
            }

            employeeRepository.Update(employee);

            return validationResult;
        }
    }
}
