﻿using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Continent where the Adventure takes place.<br/>
    /// e.g. Europe.
    /// </summary>
    public class Continent
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Continent() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name fo the Continent.</param>
        /// <param name="active">Informs if the Continent is active in SoT system.</param>
        private Continent(string name, bool active)
        {
            ContinentId = Guid.NewGuid();
            Name = name;
            Active = active;
        }

        /// <summary>
        /// Continent Unique Id.
        /// </summary>
        public Guid ContinentId { get; private set; }

        /// <summary>
        /// Name of the Continent.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the Continent is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Collection of <see cref="Region"/> attached to the Continent.
        /// </summary>
        public virtual ICollection<Region> Regions { get; private set; }

        /// <summary>
        /// Factory used when a new Continent is being added to the database context.
        /// </summary>
        /// <param name="name">Name fo the Continent.</param>
        /// <returns>See <see cref="Country"/>.</returns>
        public static Continent FactoryAdd(string name)
        {
            const bool ACTIVE = true;
            return new Continent(name, ACTIVE);
        }
    }
}
