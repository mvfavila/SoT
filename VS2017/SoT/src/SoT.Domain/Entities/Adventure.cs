using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Adventure;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Adventure. The activity offered by a provider.<br/>
    /// e.g. Kayking in Lisbon, Sky Diving in Paris.
    /// </summary>
    public class Adventure : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name fo the Adventure.</param>
        /// <param name="categoryId">Unique id of the Adventure <see cref="Entities.Category"/>.</param>
        /// <param name="cityId">Unique id of the <see cref="Entities.City"/> where the Adventure takes place.</param>
        /// <param name="addressId">Unique id of the <see cref="Entities.Address"/> where the Adventure takes place or
        /// where it starts from.</param>
        /// <param name="insurenceMinimalAmount">Minimal insurence value required by the Adventure Provider.</param>
        /// <param name="providerId">Unique id of the Adventure's <see cref="Entities.Provider"/>.</param>
        /// <param name="active">Informs if the Adventure is active in SoT system.</param>
        private Adventure(string name, Guid categoryId, Guid cityId, Guid addressId, decimal? insurenceMinimalAmount,
            Guid providerId, bool active)
        {
            AdventureId = Guid.NewGuid();
            Name = name;
            CategoryId = categoryId;
            CityId = cityId;
            AddressId = addressId;
            InsurenceMinimalAmount = insurenceMinimalAmount;
            ProviderId = providerId;
            Active = active;
        }

        /// <summary>
        /// Adventure Unique Id.
        /// </summary>
        public Guid AdventureId { get; private set; }

        /// <summary>
        /// Name fo the Adventure.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Unique id of the Adventure's <see cref="Entities.Category"/>.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// <see cref="Category"/> attached to the Adventure.
        /// </summary>
        public virtual Category Category { get; private set; }

        /// <summary>
        /// Unique id of the Adventure's <see cref="Entities.City"/>.
        /// </summary>
        public Guid CityId { get; private set; }

        /// <summary>
        /// <see cref="City"/> attached to the Adventure.
        /// </summary>
        public virtual City City { get; private set; }

        /// <summary>
        /// Unique id of the Adventure's <see cref="Entities.Adress"/>.
        /// </summary>
        public Guid AddressId { get; private set; }

        /// <summary>
        /// <see cref="Address"/> attached to the Adventure.
        /// </summary>
        public virtual Address Address { get; private set; }

        /// <summary>
        /// Minimal insurence value required by the Adventure Provider.
        /// </summary>
        public decimal? InsurenceMinimalAmount { get; private set; }

        /// <summary>
        /// Unique id of the Adventure's <see cref="Entities.Provider"/>.
        /// </summary>
        public Guid ProviderId { get; private set; }

        /// <summary>
        /// <see cref="Provider"/> attached to the Adventure.
        /// </summary>
        public virtual Provider Provider { get; private set; }

        //TODO: add calendar

        /// <summary>
        /// Informs if the Adventure is active in SoT system.
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
            var validation = new AdventureIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Adventure is being added to the database context.
        /// </summary>
        /// <param name="name">Name fo the Adventure.</param>
        /// <param name="categoryId">Unique id of the Adventure <see cref="Entities.Category"/>.</param>
        /// <param name="cityId">Unique id of the <see cref="Entities.City"/> where the Adventure takes place.</param>
        /// <param name="addressId">Unique id of the <see cref="Entities.Address"/> where the Adventure takes place or
        /// where it starts from.</param>
        /// <param name="insurenceMinimalAmount">Minimal insurence value required by the Adventure Provider.</param>
        /// <param name="providerId">Unique id of the Adventure's <see cref="Entities.Provider"/>.</param>
        /// <returns>See <see cref="Adventure"/>.</returns>
        public static Adventure FactoryAdd(string name, Guid categoryId, Guid cityId, Guid addressId,
            decimal? insurenceMinimalAmount, Guid providerId)
        {
            const bool ACVTIVE = true;
            return new Adventure(name, categoryId, cityId, addressId, insurenceMinimalAmount, providerId, ACVTIVE);
        }
    }
}
