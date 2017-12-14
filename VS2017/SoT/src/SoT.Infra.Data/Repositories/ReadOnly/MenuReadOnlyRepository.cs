using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;
using System.Collections.Generic;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class MenuReadOnlyRepository : BaseReadOnlyRepository<MenuItem, SoTContext>, IMenuReadOnlyRepository
    {
        public new IEnumerable<MenuItem> GetAll()
        {
            return new List<MenuItem>
            {
                MenuItem.FactoryLoad("Claims", "ActionName", "Controller", "Url", "AdmClaims", "True"),
                MenuItem.FactoryLoad("Adventure", "ActionName", "Controller", "Url", "AdmAdventure", "True")
            };
        }
    }
}
