using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Country;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Country where the Adventure takes place.<br/>
    /// e.g. Portugal, Spain, Germany.
    /// </summary>
    public class Country : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name of the Country.</param>
        /// <param name="active">Informs if the Country is active in SoT system.</param>
        /// <param name="elementId">Unique id of the <see cref="Entities.Region"/> attached to the Country.</param>
        private Country(string name, bool active, Guid regionId)
        {
            CountryId = Guid.NewGuid();
            Name = name;
            Active = active;
            RegionId = regionId;
        }

        /// <summary>
        /// Country Unique Id.
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Name of the Country.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the Country is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Entities.Region"/> attached to the Country.
        /// </summary>
        public Guid RegionId { get; private set; }

        /// <summary>
        /// <see cref="Entities.Region"/> attached to the Country.
        /// </summary>
        public virtual Region Region { get; private set; }

        /// <summary>
        /// Collection of <see cref="City"/> attached to the Country.
        /// </summary>
        public virtual IEnumerable<City> Cities { get; private set; }

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
            var validation = new CountryIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Country is being added to the database context.
        /// </summary>
        /// <param name="name">Name of the Country.</param>
        /// <param name="regionId">Unique id of the <see cref="Entities.Region"/> attached to the Country.</param>
        /// <returns>See <see cref="Country"/>.</returns>
        public static Country FactoryAdd(string name, Guid regionId)
        {
            const bool ACTIVE = true;
            return new Country(name, ACTIVE, regionId);
        }
    }
}
