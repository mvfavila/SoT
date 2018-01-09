using System;
using SoT.Application.ViewModels;
using SoT.Application.Validation;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IAdventureAppService : IDisposable
    {
        AdventureAddressViewModel GetById(Guid adventureId, Guid userId);

        IEnumerable<AdventureAddressViewModel> GetAllByUser(Guid userId);

        ValidationAppResult Add(AdventureAddressViewModel adventureAddressViewModel);
    }
}
