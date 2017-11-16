using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Interfaces.Services
{
    public interface ICountryService : IBaseService<Country>
    {
        new ValidationResult Add(Country country);

        new ValidationResult Update(Country country);
    }
}
