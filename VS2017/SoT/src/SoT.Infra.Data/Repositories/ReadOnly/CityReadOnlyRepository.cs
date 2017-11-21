using Dapper;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class CityReadOnlyRepository : BaseReadOnlyRepository<City, SoTContext>, ICityReadOnlyRepository
    {
        public override IEnumerable<City> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var cities = connection.Query<City>(CityQuery.GET_ALL);

                return cities;
            }
        }

        public IEnumerable<City> GetActiveByCountry(Guid countryId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var cities = connection.Query<City>(CityQuery.GET_ACTIVE_BY_COUNTRY_ID,
                    new { COUNTRY_ID = countryId });

                return cities;
            }
        }

        public override City GetById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var cities = connection.Query<City>(CityQuery.GET_BY_ID, new { ID = id });

                return cities.FirstOrDefault();
            }
        }
    }
}
