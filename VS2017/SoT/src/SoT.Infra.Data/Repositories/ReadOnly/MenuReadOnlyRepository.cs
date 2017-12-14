using Dapper;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.SQL;
using System.Collections.Generic;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class MenuReadOnlyRepository : BaseReadOnlyRepository<MenuItem, SoTContext>, IMenuReadOnlyRepository
    {
        public new IEnumerable<MenuItem> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var cities = connection.Query<MenuItem>(MenuQuery.GET_ALL_MENU_ITEMS);

                return cities;
            }
        }
    }
}
