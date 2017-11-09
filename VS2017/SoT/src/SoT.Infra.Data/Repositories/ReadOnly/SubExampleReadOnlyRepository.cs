using Dapper;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class SubExampleReadOnlyRepository : BaseReadOnlyRepository<SubExample, SoTContext>,
        ISubExampleReadOnlyRepository
    {
        public override IEnumerable<SubExample> GetAll()
        {
            // TODO: SQL Commands and Querys should be moved to a readonly Command or Query class
            const string sql = "SELECT * FROM SubExample e";

            using (var connection = Connection)
            {
                connection.Open();

                var subExamples = connection.Query<SubExample>(sql);

                return subExamples;
            }
        }

        public override SubExample GetById(Guid id)
        {
            // TODO: SQL Commands and Querys should be moved to a readonly Command or Query class
            const string sql = @"
                SELECT * FROM SubExample e
                WHERE e.SUB_EXAMPLE_ID = @SUB_EXAMPLE_ID";

            using (var connection = Connection)
            {
                connection.Open();

                var example = connection.Query<SubExample>(sql, new { SUB_EXAMPLE_ID = id });

                return example.FirstOrDefault();
            }
        }
    }
}
