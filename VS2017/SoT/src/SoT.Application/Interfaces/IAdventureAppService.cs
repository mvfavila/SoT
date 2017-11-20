using System;
using SoT.Application.ViewModels;

namespace SoT.Application.Interfaces
{
    public interface IAdventureAppService : IDisposable
    {
        AdventureAddressViewModel GetById(Guid id);
    }
}
