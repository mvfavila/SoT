using System;
using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICountryReadOnlyRepository : IBaseReadOnlyRepository<Country>
    {
        IEnumerable<Country> GetAllBySituation(bool situation);
    }
}
