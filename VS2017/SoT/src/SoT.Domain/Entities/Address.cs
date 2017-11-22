using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Address;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an Address.<br/>
    /// e.g. Address from where the Adventure will take place.
    /// </summary>
    public class Address : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Address() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="street01">Street's Address.</param>
        /// <param name="complement">Street's Address' Complement.</param>
        /// <param name="postcode">Address' Postcode.</param>
        /// <param name="adventureId">Unique id of the <see cref="Entities.Adventure"/> to which the Address belongs.
        /// </param>
        private Address(string street01, string complement, string postcode, Guid adventureId)
        {
            AddressId = Guid.NewGuid();
            Street01 = street01;
            Complement = complement;
            Postcode = postcode;
            AdventureId = adventureId;
        }

        /// <summary>
        /// Address Unique Id.
        /// </summary>
        public Guid AddressId { get; private set; }

        /// <summary>
        /// Street's Address.
        /// </summary>
        public string Street01 { get; private set; }

        /// <summary>
        /// Street's Address' Complement.
        /// </summary>
        public string Complement { get; private set; }

        /// <summary>
        /// Address' Postcode.
        /// Ex.: 4102, EC, 49040-000.
        /// </summary>
        public string Postcode { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Entities.Adventure"/> to which the Address belongs.
        /// </summary>
        public Guid AdventureId { get; private set; }

        /// <summary>
        /// <see cref="Adventure"/> attached to the Address.
        /// </summary>
        public virtual Adventure Adventure { get; private set; }

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
            var validation = new AddressIsVerified();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Method used internally to attach the Adventure to the current Address.
        /// </summary>
        /// <param name="adventure">See <see cref="Entities.Adventure"/>.</param>
        internal void AttachAdventure(Adventure adventure)
        {
            Adventure = adventure;
            AdventureId = adventure.AdventureId;
        }

        /// <summary>
        /// Factory used when a new Address is being added to the database context.
        /// </summary>
        /// <param name="street01">Street's Address.</param>
        /// <param name="complement">Street's Address' Complement.</param>
        /// <param name="postcode">Address' Postcode.</param>
        /// <param name="adventureId">Unique id of the <see cref="Entities.Adventure"/> to which the Address belongs.
        /// </param>
        /// <returns>See <see cref="Address"/>.</returns>
        public static Address FactoryAdd(string street01, string complement, string postcode, Guid adventureId)
        {
            return new Address(street01, complement, postcode, adventureId);
        }
    }
}
