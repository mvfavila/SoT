using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;

namespace SoT.Application.AppServices
{
    public class CategoryAppService : BaseAppService<SoTContext>, ICategoryAppService
    {
        private readonly ICategoryService categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public void Dispose()
        {
            categoryService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
