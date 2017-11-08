using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Provider;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Provider of an Adventure.<br/>
    /// </summary>
    public class Provider : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Provider() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <param name="active">Informs if the Provider is active in SoT system.</param>
        private Provider(string companyName, bool active)
        {
            ProviderId = Guid.NewGuid();
            CompanyName = companyName;
            Active = active;
        }

        /// <summary>
        /// Provider Unique Id.
        /// </summary>
        public Guid ProviderId { get; private set; }

        /// <summary>
        /// Adventure Provider's company name.
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// Collection of <see cref="Adventure"/> attached to the Provider.
        /// </summary>
        public virtual IEnumerable<Adventure> Adventures { get; private set; }

        /// <summary>
        /// Collection of <see cref="Employee"/> attached to the Provider.
        /// </summary>
        public virtual IEnumerable<Employee> Employees { get; private set; }

        /// <summary>
        /// Informs if the Provider is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

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
            var validation = new ProviderIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Provider is being added to the database context.
        /// </summary>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <returns>See <see cref="Provider"/>.</returns>
        public static Provider FactoryAdd(string companyName)
        {
            const bool ACVTIVE = true;
            return new Provider(companyName, ACVTIVE);
        }
    }
}
