﻿using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the region where the Adventure takes place.<br/>
    /// e.g. East Europe.
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name of the Region.</param>
        /// <param name="active">Informs if the Region is active in SoT system.</param>
        /// <param name="continentId">Unique id of the <see cref="Entities.Continent"/> where the Region is located.
        /// </param>
        private Region(string name, bool active, Guid continentId)
        {
            RegionId = Guid.NewGuid();
            Name = name;
            Active = active;
            ContinentId = continentId;
        }

        /// <summary>
        /// Region Unique Id.
        /// </summary>
        public Guid RegionId { get; private set; }

        /// <summary>
        /// Name of the Region.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the Region is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Entities.Continent"/> where the Region is located.
        /// </summary>
        public Guid ContinentId { get; private set; }

        /// <summary>
        /// <see cref="Entities.Continent"/> attached to the Region.
        /// </summary>
        public virtual Continent Continent { get; private set; }

        /// <summary>
        /// Collection of <see cref="Country"/> attached to the Region.
        /// </summary>
        public virtual IEnumerable<Country> Countries { get; private set; }

        /// <summary>
        /// Factory used when a new Region is being added to the database context.
        /// </summary>
        /// <param name="name">Name of the Region.</param>
        /// <param name="ContinentId">Unique id of the <see cref="Entities.Continent"/> where the Region is located.
        /// </param>
        /// <returns>See <see cref="Region"/>.</returns>
        public static Region FactoryAdd(string name, Guid continentId)
        {
            const bool ACVTIVE = true;
            return new Region(name, ACVTIVE, continentId);
        }
    }
}