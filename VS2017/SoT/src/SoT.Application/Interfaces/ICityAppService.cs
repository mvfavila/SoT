using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface ICityAppService : IDisposable
    {
        IEnumerable<CityViewModel> GetAll();

        IEnumerable<CityViewModel> GetActiveByCountry(Guid countryId);

        CityViewModel GetById(Guid id);
    }
}
