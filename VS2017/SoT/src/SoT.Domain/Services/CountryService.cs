using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly ICountryReadOnlyRepository countryReadOnlyRepository;

        public CountryService(ICountryRepository countryRepository,
            ICountryReadOnlyRepository countryReadOnlyRepository)
            : base(countryRepository, countryReadOnlyRepository)
        {
            this.countryRepository = countryRepository;
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
