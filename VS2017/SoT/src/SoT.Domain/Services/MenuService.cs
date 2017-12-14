using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;

namespace SoT.Domain.Services
{
    public class MenuService : BaseService<MenuItem>, IMenuService
    {
        private readonly IMenuReadOnlyRepository menuReadOnlyRepository;

        public MenuService(IMenuReadOnlyRepository menuReadOnlyRepository)
            : base(null, menuReadOnlyRepository)
        {
            this.menuReadOnlyRepository = menuReadOnlyRepository;
        }
    }
}
