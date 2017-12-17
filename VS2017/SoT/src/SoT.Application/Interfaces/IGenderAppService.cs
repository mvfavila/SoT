using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IGenderAppService : IDisposable
    {
        IEnumerable<GenderViewModel> GetAllActive();
    }
}
