using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        IEnumerable<CategoryViewModel> GetAll();

        IEnumerable<CategoryViewModel> GetAllActive();
    }
}
