using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Employee;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an Employee/Owner of a Adventure Provider.
    /// </summary>
    public class Employee : User, ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Employee() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Employee's name.</param>
        /// <param name="surname">Employee's surname.</param>
        /// <param name="birthDate">Employee's birth date.</param>
        private Employee(string name, string surname, DateTime birthDate)
            : base()
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Employee's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Employee's surname.
        /// </summary>
        public string Surname { get; private set; }

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
        /// <param name="name">Employee's name.</param>
        /// <param name="surname">Employee's surname.</param>
        /// <param name="birthDate">Employee's birth date.</param>
        /// <returns>See <see cref="Employee"/>.</returns>
        public static Employee FactoryAdd(string name, string surname, DateTime birthDate)
        {
            return new Employee(name, surname, birthDate);
        }

        /// <summary>
        /// Factory used when Mapping from a View Model to a <see cref="Employee"/>.
        /// </summary>
        /// <param name="id">Employee's Unique Id.</param>
        /// <param name="name">Employee's name.</param>
        /// <param name="surname">Employee's surname.</param>
        /// <param name="email">Employee's e-mail</param>
        /// <param name="birthDate">Employee's birth date.</param>
        /// <param name="provider"><see cref="Entities.Provider"/> where the Employee works or which is owned by the
        /// Employee.</param>
        /// <returns>See <see cref="Employee"/>.</returns>
        public static Employee FactoryMap(Guid id, string name, string surname, string email, DateTime birthDate,
            Provider provider)
        {
            return new Employee
            {
                Id = id.ToString(),
                UserName = email,
                Email = email,
                Name = name,
                Surname = surname,
                BirthDate = birthDate,
                ProviderId = provider.ProviderId,
                Provider = provider
            };
        }
    }
}
