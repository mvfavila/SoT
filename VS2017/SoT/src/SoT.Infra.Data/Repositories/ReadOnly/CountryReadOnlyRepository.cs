using System;
using System.Collections.Generic;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using Dapper;
using System.Linq;
using SoT.Infra.Data.SQL;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class CountryReadOnlyRepository : BaseReadOnlyRepository<Country, SoTContext>, ICountryReadOnlyRepository
    {
        public override IEnumerable<Country> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var countries = connection.Query<Country>(CountryQuery.GET_ALL);

                return countries;
            }
        }

        public override Country GetById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var countries = connection.Query<Country>(CountryQuery.GET_BY_ID, new { ID = id });

                return countries.FirstOrDefault();
            }
        }
    }
}
