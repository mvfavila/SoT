using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using SoT.Application.ViewModels;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class CategoryAppService : BaseAppService<SoTContext>, ICategoryAppService
    {
        private readonly ICategoryService categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = categoryService.GetAll();

            return Mapping.CategoryMapper.FromDomainToViewModel(categories);
        }

        public void Dispose()
        {
            categoryService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
