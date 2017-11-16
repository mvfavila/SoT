using SoT.Application.Validation;
using SoT.Application.ViewModels;
using System;

namespace SoT.Application.Interfaces
{
    public interface ICountryAppService : IDisposable
    {
        CountryViewModel GetById(Guid id);

        ValidationAppResult Add(CountryViewModel countryViewModel);

        ValidationAppResult Update(CountryViewModel countryViewModel);
    }
}
