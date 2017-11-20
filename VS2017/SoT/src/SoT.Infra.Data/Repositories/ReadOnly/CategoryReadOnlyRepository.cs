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
    public class CategoryReadOnlyRepository : BaseReadOnlyRepository<Category, SoTContext>, ICategoryReadOnlyRepository
    {
        public override IEnumerable<Category> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var categories = connection.Query<Category>(CategoryQuery.GET_ALL);

                return categories;
            }
        }

        public override Category GetById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var categories = connection.Query<Category>(CategoryQuery.GET_BY_ID, new { ID = id });

                return categories.FirstOrDefault();
            }
        }
    }
}
