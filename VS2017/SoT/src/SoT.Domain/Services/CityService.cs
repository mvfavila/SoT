using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;

namespace SoT.Domain.Services
{
    public class CityService : BaseService<City>, ICityService
    {
        private readonly ICityRepository cityRepository;
        private readonly ICityReadOnlyRepository cityReadOnlyRepository;

        public CityService(ICityRepository cityRepository, ICityReadOnlyRepository cityReadOnlyRepository)
            : base(cityRepository, cityReadOnlyRepository)
        {
            this.cityRepository = cityRepository;
            this.cityReadOnlyRepository = cityReadOnlyRepository;
        }

    }
}
