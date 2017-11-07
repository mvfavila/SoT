using SoT.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    /// <summary>
    /// Read-only repository of <see cref="Claim"/>.
    /// </summary>
    public interface IClaimReadOnlyRepository : IDisposable
    {
        /// <summary>
        /// Gets all the existing Claim in the database context.
        /// </summary>
        /// <returns>Collection of <see cref="Claim"/>.</returns>
        IEnumerable<Claim> GetAll();
    }
}
