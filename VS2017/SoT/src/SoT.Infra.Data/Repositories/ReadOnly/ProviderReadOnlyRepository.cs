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
    public class ProviderReadOnlyRepository : BaseReadOnlyRepository<Provider, SoTContext>, IProviderReadOnlyRepository
    {
        public override IEnumerable<Provider> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var providers = connection.Query<Provider>(ProviderQuery.GET_ALL);

                return providers;
            }
        }

        public override Provider GetById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var example = connection.Query<Provider>(ProviderQuery.GET_BY_ID, new { ID = id });

                return example.FirstOrDefault();
            }
        }

        public Provider GetWithEmployeeById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var providerWithEmployees = connection.Query<Provider, Employee, Provider>(
                    ProviderQuery.GET_WITH_EMPLOYEE_BY_ID,
                    (provider, employee) =>
                    {
                        provider.Employees.ToList().Add(employee);
                        return provider;
                    },
                    new { ID = id },
                    splitOn: "Id, EmployeeId");

                return providerWithEmployees.FirstOrDefault();
            }
        }
    }
}
