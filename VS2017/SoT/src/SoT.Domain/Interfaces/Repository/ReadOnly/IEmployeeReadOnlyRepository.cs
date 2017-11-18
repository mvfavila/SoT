using SoT.Domain.Entities;
using System;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IEmployeeReadOnlyRepository : IBaseReadOnlyRepository<Employee>
    {
    }
}
