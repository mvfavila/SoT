using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Interfaces.Services
{
    /// <summary>
    /// Domain layer's Claim's Service.
    /// </summary>
    public interface IClaimService : IDisposable
    {
        IEnumerable<Claim> GetActive();

        /// <summary>
        /// Gets all the existing <see cref="Claim"/> in the data repository.
        /// </summary>
        /// <returns>Collection of <see cref="Claim"/>.</returns>
        IEnumerable<Claim> GetAll();

        IEnumerable<Claim> Find(Expression<Func<Claim, bool>> predicate);

        Claim GetById(Guid id);

        ValidationResult Add(Claim claim);

        void Update(Claim claim);

        void Delete(Guid id);
    }
}
