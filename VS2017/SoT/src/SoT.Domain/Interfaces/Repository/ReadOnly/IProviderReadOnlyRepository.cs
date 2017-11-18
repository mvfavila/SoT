using SoT.Domain.Entities;
using System;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IProviderReadOnlyRepository : IBaseReadOnlyRepository<Provider>
    {
        Provider GetWithEmployeeById(Guid userId);
    }
}
