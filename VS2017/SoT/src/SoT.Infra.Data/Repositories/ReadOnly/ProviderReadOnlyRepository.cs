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

        /// <summary>
        /// Gets the Provider from the data repository along with all the information attached to it e.g. The employee
        /// attached to the Provider.
        /// </summary>
        /// <param name="userId">User id fetched from the system.</param>
        /// <returns>See <see cref="Provider"/>.</returns>
        public Provider GetWithEmployeeById(Guid userId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var providerWithEmployees = connection.Query<Provider, Employee, Provider>(
                        ProviderQuery.GET_WITH_EMPLOYEE_BY_ID,
                        (provider, employee) =>
                        {
                            provider.AddEmployee(employee);
                            return provider;
                        },
                        new { ID = userId })
                    .ToList();

                return providerWithEmployees.FirstOrDefault();
            }
        }
    }
}
