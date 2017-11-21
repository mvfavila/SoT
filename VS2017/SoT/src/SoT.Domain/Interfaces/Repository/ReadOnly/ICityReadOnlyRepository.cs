using System;
using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICityReadOnlyRepository : IBaseReadOnlyRepository<City>
    {
        IEnumerable<City> GetActiveByCountry(Guid countryId);
    }
}
