using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Interfaces.Services
{
    public interface IProviderService : IDisposable
    {
        Provider GetById(Guid id);

        ValidationResult Add(Provider provider);

        ValidationResult Update(Provider provider);

        void Delete(Guid id);
    }
}
