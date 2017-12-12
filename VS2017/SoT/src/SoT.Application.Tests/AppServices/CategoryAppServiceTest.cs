using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Linq;
using System.Web;
using Xunit;

namespace SoT.Application.Tests.AppServices
{
    public class CategoryAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public CategoryAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get all active Categories")]
        [Trait(nameof(Category), "App Service")]
        public void Category_GetAllActive_Sucess()
        {
            // Arrange
            var categories = new Faker<Category>()
                .CustomInstantiator(c => Category.FactoryTest(
                    Guid.NewGuid(),
                    c.Commerce.Categories(1)[0],
                    true,
                    Guid.NewGuid(),
                    null)).Generate(100);

            mocker.Create<CategoryAppService>();
            var categoryAppService = mocker.Resolve<CategoryAppService>();
            var categoryService = mocker.GetMock<ICategoryService>();
            categoryService
                .Setup(c => c.GetAllActive())
                .Returns(categories);

            // Act
            var categoryViewModels = categoryAppService.GetAllActive().ToList();

            // Assert
            categoryService.Verify(c => c.GetAllActive(), Times.Once());
            for (int i = 0; i < categories.Count; i++)
            {
                Assert.Equal(categories[i].CategoryId, categoryViewModels[i].CategoryId);
                Assert.Equal(categories[i].Name, categoryViewModels[i].Name);
                Assert.Equal(categories[i].Active, categoryViewModels[i].Active);
                Assert.Equal(categories[i].ElementId, categoryViewModels[i].ElementId);
            }
        }
    }
}
