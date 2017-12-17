using SoT.Domain.Interfaces.Validation;
using System;
using SoT.Domain.ValueObjects;
using SoT.Domain.Validation.Gender;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents a Gender.<br/>
    /// e.g. Male, Female.
    /// </summary>
    public class Gender : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Gender()
        {
            GenderId = Guid.NewGuid();
        }

        /// <summary>
        /// Gender Unique Id.
        /// </summary>
        public Guid GenderId { get; private set; }

        /// <summary>
        /// Gender Value.<br/>
        /// e.g. Male, Female.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Informs if the Gender is active in SoT system.
        /// </summary>
        public bool Active { get; set; }

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
            var validation = new GenderIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used to seed the database context.
        /// </summary>
        /// <param name="value">Gender Value.</param>
        /// <param name="active">Informs if the Gender is active in SoT system.</param>
        /// <returns>See <see cref="Gender"/>.</returns>
        public static Gender FactorySeed(string value, bool active)
        {
            return new Gender
            {
                Value = value,
                Active = active
            };
        }

        /// <summary>
        /// Factory used for Gender's Unit Tests.
        /// </summary>
        /// <param name="genderId">Gender Unique Id.</param>
        /// <param name="value">Gender Value.</param>
        /// <param name="active">Informs if the Gender is active in SoT system.</param>
        /// <returns>See <see cref="Gender"/>.</returns>
        public static Gender FactoryTest(Guid genderId, string value, bool active)
        {
            return new Gender
            {
                GenderId = genderId,
                Value = value,
                Active = active
            };
        }
    }
}
