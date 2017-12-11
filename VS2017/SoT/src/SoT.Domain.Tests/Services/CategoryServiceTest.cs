using AutoMoq;
using Moq;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class CategoryServiceTest
    {
        private readonly AutoMoqer mocker;

        public CategoryServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get All Active Categories")]
        [Trait("Category", "Domain Service")]
        public void Category_GetAllActive_Sucess()
        {
            // Arrange
            mocker.Create<CategoryService>();

            var categoryService = mocker.Resolve<CategoryService>();
            var categoryRepository = mocker.GetMock<ICategoryReadOnlyRepository>();

            // Act
            categoryService.GetAllActive();

            // Assert
            categoryRepository.Verify(a => a.GetAllBySituation(It.Is<bool>(s => s)), Times.Once());
        }
    }
}
