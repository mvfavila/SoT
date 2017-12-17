using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Services
{
    public interface IGenderService : IBaseService<Gender>
    {
        IEnumerable<Gender> GetAllActive();
    }
}
