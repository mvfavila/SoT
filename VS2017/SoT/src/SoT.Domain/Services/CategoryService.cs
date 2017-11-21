using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;

namespace SoT.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryReadOnlyRepository categoryReadOnlyRepository;

        public CategoryService(ICategoryRepository categoryRepository,
            ICategoryReadOnlyRepository categoryReadOnlyRepository)
            : base(categoryRepository, categoryReadOnlyRepository)
        {
            this.categoryRepository = categoryRepository;
            this.categoryReadOnlyRepository = categoryReadOnlyRepository;
        }
    }
}
