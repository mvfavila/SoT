using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Interfaces.Services
{
    public interface IProviderService : IBaseService<Provider>
    {
        new ValidationResult Add(Provider provider);

        new ValidationResult Update(Provider provider);
    }
}
