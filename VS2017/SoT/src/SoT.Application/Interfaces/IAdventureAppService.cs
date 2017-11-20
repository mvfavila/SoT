using System;
using SoT.Application.ViewModels;

namespace SoT.Application.Interfaces
{
    public interface IAdventureAppService : IDisposable
    {
        AdventureAddressViewModel GetById(Guid adventureId, Guid userId);
    }
}
