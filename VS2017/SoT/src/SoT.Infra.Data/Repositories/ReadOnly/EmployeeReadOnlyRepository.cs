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
    public class EmployeeReadOnlyRepository : BaseReadOnlyRepository<Employee, SoTContext>, IEmployeeReadOnlyRepository
    {
        public override IEnumerable<Employee> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var employees = connection.Query<Employee>(EmployeeQuery.GET_ALL);

                return employees;
            }
        }

        public override Employee GetById(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var employees = connection.Query<Employee>(ProviderQuery.GET_BY_ID, new { ID = id });

                return employees.FirstOrDefault();
            }
        }
    }
}
