﻿using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Provider;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private Provider()
        {
            Employees = new List<Employee>();
            Adventures = new List<Adventure>();
        }

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
            Employees = new List<Employee>();
            Adventures = new List<Adventure>();
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
        /// Date when the Provider was registered in the SumOfThis.
        /// </summary>
        public DateTime RegisterDate { get; private set; }

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
        /// Adds a new Employee to the Adventure Provider.
        /// </summary>
        /// <param name="employee">See <see cref="Employee"/>.</param>
        public void AddEmployee(Employee employee)
        {
            if (Employees == null)
                Employees = new List<Employee>();

            employee.AttachProvider(this);

            var list = Employees.ToList();
            list.Add(employee);
            Employees = list;
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

        /// <summary>
        /// Factory used when Mapping from a View Model to a <see cref="Provider"/>.
        /// </summary>
        /// <param name="providerId">Provider Unique Id.</param>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <param name="adventures">Collection of <see cref="Adventure"/> attached to the Provider.</param>
        /// <param name="employees">Collection of <see cref="Employee"/> attached to the Provider.</param>
        /// <param name="active">Informs if the Provider is active in SoT system.</param>
        /// <param name="registerDate">Date when the Provider was registered in the SumOfThis.</param>
        /// <returns>See <see cref="Provider"/>.</returns>
        public static Provider FactoryMap(Guid providerId, string companyName, ICollection<Adventure> adventures,
            ICollection<Employee> employees, bool active, DateTime registerDate)
        {
            return new Provider
            {
                ProviderId = providerId,
                CompanyName = companyName,
                Adventures = adventures,
                Employees = employees,
                Active = active,
                RegisterDate = registerDate
            };
        }

        /// <summary>
        /// Factory used for Provider's Unit Tests.
        /// </summary>
        /// <param name="providerId">Provider Unique Id.</param>
        /// <param name="companyName">Adventure Provider's company name.</param>
        /// <param name="adventures">Collection of <see cref="Adventure"/> attached to the Provider.</param>
        /// <param name="employees">Collection of <see cref="Employee"/> attached to the Provider.</param>
        /// <param name="active">Informs if the Provider is active in SoT system.</param>
        /// <returns>See <see cref="Provider"/>.</returns>
        public static Provider FactoryTest(Guid providerId, string companyName, ICollection<Adventure> adventures,
            ICollection<Employee> employees, bool active)
        {
            return new Provider
            {
                ProviderId = providerId,
                CompanyName = companyName,
                Adventures = adventures,
                Employees = employees,
                Active = active
            };
        }
    }
}
