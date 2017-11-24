using System;
using SoT.Application.ViewModels;
using SoT.Application.Validation;

namespace SoT.Application.Interfaces
{
    public interface IAdventureAppService : IDisposable
    {
        AdventureAddressViewModel GetById(Guid adventureId, Guid userId);

        ValidationAppResult Add(AdventureAddressViewModel adventureAddressViewModel);
    }
}
