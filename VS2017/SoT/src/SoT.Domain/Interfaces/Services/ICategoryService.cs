using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        IEnumerable<Category> GetAllActive();
    }
}
