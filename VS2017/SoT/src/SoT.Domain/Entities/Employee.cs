using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Employee;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an Employee/Owner of a Adventure Provider.
    /// </summary>
    public class Employee : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Employee() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="birthDate">Employee's birth date.</param>
        private Employee(DateTime birthDate)
            : base()
        {
            EmployeeId = Guid.NewGuid();
            BirthDate = birthDate;
        }

        /// <summary>
        /// Employee Unique Id.
        /// </summary>
        public Guid EmployeeId { get; private set; }

        /// <summary>
        /// Employee's birth date.
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Provider"/> attached to the Employee.
        /// </summary>
        public Guid ProviderId { get; private set; }

        /// <summary>
        /// <see cref="Entities.Provider"/> where the Employee works or which is owned by the Employee.
        /// </summary>
        public virtual Provider Provider { get; private set; }

        /// <summary>
        /// Unique id of the ApplicationUser attached to the Employee.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// See <see cref="ValueObjects.ValidationResult"/>.
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// See <see cref="ISelfValidator.IsValid"/>.
        /// </summary>
        /// <returns>See <see cref="ISelfValidator.IsValid"/>.</returns>
        public bool IsValid()
        {
            var validation = new EmployeeIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Employee is being added to the database context.
        /// </summary>
        /// <param name="birthDate">Employee's birth date.</param>
        /// <returns>See <see cref="Employee"/>.</returns>
        public static Employee FactoryAdd(DateTime birthDate)
        {
            return new Employee(birthDate);
        }

        /// <summary>
        /// Factory used when Mapping from a View Model to a <see cref="Employee"/>.
        /// </summary>
        /// <param name="employeeId">Employee's Unique Id.</param>
        /// <param name="birthDate">Employee's birth date.</param>
        /// <param name="provider"><see cref="Entities.Provider"/> where the Employee works or which is owned by the
        /// Employee.</param>
        /// <param name="userId">Unique id of the <see cref="Entities.User"/> attached to the Employee.</param>
        /// <returns>See <see cref="Employee"/>.</returns>
        public static Employee FactoryMap(Guid employeeId, DateTime birthDate, Provider provider, Guid userId)
        {
            return new Employee
            {
                EmployeeId = employeeId,
                BirthDate = birthDate,
                ProviderId = provider.ProviderId,
                Provider = provider,
                UserId = userId
            };
        }
    }
}
