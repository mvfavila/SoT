using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the City where the Adventure takes place.<br/>
    /// e.g. Lisbon, Rome, Berlin.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name fo the City.</param>
        /// <param name="active">Informs if the City is active in SoT system.</param>
        /// <param name="countryId">Unique id of the <see cref="Entities.Country"/> where the City is located.</param>
        private City(string name, bool active, Guid countryId)
        {
            CityId = Guid.NewGuid();
            Name = name;
            Active = active;
            CountryId = countryId;
        }

        /// <summary>
        /// City Unique Id.
        /// </summary>
        public Guid CityId { get; private set; }

        /// <summary>
        /// Name of the City.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the City is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Entities.Country"/> where the City is located.
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Collection of <see cref="Country"/> attached to the City.
        /// </summary>
        public virtual Country Country { get; private set; }

        /// <summary>
        /// Factory used when a new City is being added to the database context.
        /// </summary>
        /// <param name="name">Name of the City.</param>
        /// <param name="countryId">Unique id of the <see cref="Entities.Country"/> where the City is located.</param>
        /// <returns>See <see cref="City"/>.</returns>
        public static City FactoryAdd(string name, Guid countryId)
        {
            const bool ACVTIVE = true;
            return new City(name, ACVTIVE, countryId);
        }
    }
}