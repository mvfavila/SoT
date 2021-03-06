﻿using Dapper;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Linq;
using System.Collections.Generic;
using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class ExampleReadOnlyRepository : BaseReadOnlyRepository<Example, SoTContext>, IExampleReadOnlyRepository
    {
        public override IEnumerable<Example> GetAll()
        {
            // TODO: SQL Commands and Querys should be moved to a readonly Command or Query class
            const string sql = "SELECT * FROM Example e";

            using (var connection = Connection)
            {
                connection.Open();

                var examples = connection.Query<Example>(sql);

                return examples;
            }
        }

        public IEnumerable<Example> GetActive()
        {
            throw new NotImplementedException();
        }

        public override Example GetById(Guid id)
        {
            // TODO: SQL Commands and Querys should be moved to a readonly Command or Query class
            const string sql = @"
                SELECT * FROM Example e
                WHERE e.EXAMPLE_ID = @EXAMPLE_ID";

            using (var connection = Connection)
            {
                connection.Open();

                var example = connection.Query<Example>(sql, new { EXAMPLE_ID = id });

                return example.FirstOrDefault();
            }
        }

        public Example GetWithSubExampleById(Guid id)
        {
            // TODO: SQL Commands and Querys should be moved to a readonly Command or Query class
            // TODO: parameters must be passed using frameworks avoiding SQL Injection
            const string sql = "SELECT * FROM Example e" +
                        "INNER JOIN SubExample se ON e.ExampleId = se.ExampleId" +
                        "WHERE e.EXAMPLE_ID = @EXAMPLE_ID";

            using (var connection = Connection)
            {
                connection.Open();

                var exampleWithSubExample = connection.Query<Example, SubExample, Example>(sql,
                    (example, subExample) =>
                    {
                        example.SubExamples.ToList().Add(subExample);
                        return example;
                    },
                    new { EXAMPLE_ID = id },
                    splitOn: "ExampleId, SubExampleId");

                return exampleWithSubExample.FirstOrDefault();
            }
        }
    }
}
