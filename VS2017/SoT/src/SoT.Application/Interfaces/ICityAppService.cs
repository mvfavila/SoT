using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface ICityAppService : IDisposable
    {
        IEnumerable<CityViewModel> GetAll();
    }
}
