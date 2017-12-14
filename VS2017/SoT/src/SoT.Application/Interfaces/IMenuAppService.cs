using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IMenuAppService : IDisposable
    {
        IEnumerable<MenuItemViewModel> GetByClaims(List<Tuple<string, string>> claims);
    }
}
