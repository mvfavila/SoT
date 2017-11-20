using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Availability;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an Adventure Availability for booking by an Adventurer/Client.
    /// e.g. Sky Diving in Lisbon on 20th of January 2017.
    /// </summary>
    public class Availability : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Availability() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="date">Date when the Adventure is Available to be scheduled.</param>
        /// <param name="startTime">Time when the Adventure starts.</param>
        /// <param name="durationMinimum">Minimum duration of the Adventure.</param>
        /// <param name="durationMaximum">Maximum duration of the Adventure.</param>
        /// <param name="capacity">Maximum capacity of this Adventure Availability.</param>
        /// <param name="adventureId">Unique Id of the <see cref="Entities.Adventure"/> that has the current
        /// Availability.</param>
        /// <param name="active">Informs if the Availability is active in SoT system.</param>
        private Availability(DateTime date, TimeSpan startTime, TimeSpan durationMinimum, TimeSpan durationMaximum,
            int capacity, Guid adventureId, bool active)
        {
            AvailabilityId = Guid.NewGuid();
            Date = date;
            StartTime = startTime;
            DurationMinimum = durationMinimum;
            DurationMaximum = durationMaximum;
            Capacity = capacity;
            AdventureId = adventureId;
            Active = active;
        }

        /// <summary>
        /// Availability Unique Id.
        /// </summary>
        public Guid AvailabilityId { get; private set; }

        /// <summary>
        /// Date when the Adventure is Available to be scheduled.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Time when the Adventure starts.
        /// </summary>
        public TimeSpan StartTime { get; private set; }

        /// <summary>
        /// Minimum duration of the Adventure.
        /// </summary>
        public TimeSpan DurationMinimum { get; private set; }

        /// <summary>
        /// Maximum duration of the Adventure.
        /// </summary>
        public TimeSpan DurationMaximum { get; private set; }

        /// <summary>
        /// Maximum capacity of this Adventure Availability.
        /// </summary>
        public int Capacity { get; private set; }

        /// <summary>
        /// Unique Id of the <see cref="Entities.Adventure"/> that has the current Availability.
        /// </summary>
        public Guid AdventureId { get; private set; }

        /// <summary>
        /// <see cref="Entities.Adventure"/> that has the current Availability.
        /// </summary>
        public Adventure Adventure { get; private set; }

        /// <summary>
        /// Informs if the Availability is active in SoT system.
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
            var validation = new AvailabilityIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Availability is being added to the database context.
        /// </summary>
        /// <param name="date">Date when the Adventure is Available to be scheduled.</param>
        /// <param name="startTime">Time when the Adventure starts.</param>
        /// <param name="durationMinimum">Minimum duration of the Adventure.</param>
        /// <param name="durationMaximum">Maximum duration of the Adventure.</param>
        /// <param name="capacity">Maximum capacity of this Adventure Availability.</param>
        /// <param name="adventureId">Unique Id of the <see cref="Entities.Adventure"/> that has the current
        /// Availability.</param>
        /// <returns>See <see cref="Availability"/>.</returns>
        public static Availability FactoryAdd(DateTime date, TimeSpan startTime, TimeSpan durationMinimum,
            TimeSpan durationMaximum, int capacity, Guid adventureId)
        {
            const bool ACVTIVE = true;
            return new Availability(date, startTime, durationMinimum, durationMaximum, capacity, adventureId, ACVTIVE);
        }
    }
}
