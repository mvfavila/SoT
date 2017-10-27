﻿using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Provider of an Adventure.<br/>
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="email">Adventure Provider's unique e-mail/login.</param>
        /// <param name="name">Adventure Provider's name.</param>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <param name="active">Informs if the Provider is active in SoT system.</param>
        private Provider(string email, string name, string companyName, bool active)
        {
            ProviderId = Guid.NewGuid();
            Email = email;
            Name = name;
            Active = active;
        }

        /// <summary>
        /// Provider Unique Id.
        /// </summary>
        public Guid ProviderId { get; private set; }

        /// <summary>
        /// Adventure Provider's unique e-mail/login.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Adventure Provider's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Adventure Provider's company name.
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// Informs if the Provider is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Factory used when a new Provider is being added to the database context.
        /// </summary>
        /// <param name="email">Adventure Provider's unique e-mail/login.</param>
        /// <param name="name">Adventure Provider's name.</param>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <returns>See <see cref="Provider"/>.</returns>
        public Provider FactoryAdd(string email, string name, string companyName)
        {
            const bool ACVTIVE = true;
            return new Provider(email, name, companyName, ACVTIVE);
        }
    }
}