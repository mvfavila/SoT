using Dapper;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.SQL;
using System.Collections.Generic;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class GenderReadOnlyRepository : BaseReadOnlyRepository<Gender, SoTContext>, IGenderReadOnlyRepository
    {
        public IEnumerable<Gender> GetAllBySituation(bool situation)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var countries = connection.Query<Gender>(GenderQuery.GET_ALL_BY_SITUATION,
                    new { SITUATION = situation });

                return countries;
            }
        }
    }
}
