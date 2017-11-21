using System;
using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Services
{
    public interface ICityService : IBaseService<City>
    {
        IEnumerable<City> GetActiveByCountry(Guid countryId);
    }
}
