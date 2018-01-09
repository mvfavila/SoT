using Dapper;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.SQL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class AdventureReadOnlyRepository : BaseReadOnlyRepository<Adventure, SoTContext>,
        IAdventureReadOnlyRepository
    {
        /// <summary>
        /// Gets the Adventure from the data repository along with all the information attached to it.<br/>
        /// e.g. The Adventure's Address.
        /// </summary>
        /// <param name="adventureId">Adventure Unique Id.</param>
        /// <param name="userId">Logged User Unique Id.</param>
        /// <returns>See <see cref="Adventure"/>.</returns>
        public Adventure GetWithAddressById(Guid adventureId, Guid userId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var adventureWithAddress = connection.Query<Adventure, Address, Adventure>(
                        AdventureQuery.GET_WITH_ADDRESS_BY_ID,
                        (adventure, address) =>
                        {
                            adventure.AddAddress(address);
                            return adventure;
                        },
                        new { ID = adventureId, USER_ID = userId })
                    .ToList();

                return adventureWithAddress.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the Adventure from the data repository along with all the information attached to it by Provider's
        /// Employee's User Id.
        /// </summary>
        /// <param name="userId">Logged User Unique Id.</param>
        /// <returns>See <see cref="Adventure"/>.</returns>
        public IEnumerable<Adventure> GetAllWithAddressById(Guid userId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var adventureWithAddress = connection.Query<Adventure, Address, Adventure>(
                        AdventureQuery.GET_ALL_WITH_ADDRESS_BY_USER_ID,
                        (adventure, address) =>
                        {
                            adventure.AddAddress(address);
                            return adventure;
                        },
                        new { USER_ID = userId })
                    .ToList();

                return adventureWithAddress;
            }
        }
    }
}
