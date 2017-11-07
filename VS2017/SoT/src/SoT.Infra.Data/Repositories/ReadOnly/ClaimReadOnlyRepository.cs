using SoT.Domain.Interfaces.Repository.ReadOnly;
using System;
using SoT.Domain.Entities;
using System.Collections.Generic;
using Dapper;
using SoT.Infra.Data.SQL.Claim;
using System.Data;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ClaimReadOnlyRepository : BaseReadOnlyRepository, IClaimReadOnlyRepository
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>See <see cref="IClaimReadOnlyRepository.GetAll"/>.</returns>
        public IEnumerable<Claim> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var claims = connection.Query<Claim>(ClaimQuery.GET_ALL);

                return claims;
            }
        }

        /// <summary>
        /// See <see cref="IDisposable.Dispose"/>.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
