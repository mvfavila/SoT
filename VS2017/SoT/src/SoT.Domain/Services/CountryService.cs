using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly ICountryReadOnlyRepository countryReadOnlyRepository;

        public CountryService(ICountryReadOnlyRepository countryReadOnlyRepository)
            : base(null, countryReadOnlyRepository)
        {
            this.countryReadOnlyRepository = countryReadOnlyRepository;
        }

        ValidationResult ICountryService.Add(Country country)
        {
            throw new NotImplementedException();
        }

        ValidationResult ICountryService.Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
