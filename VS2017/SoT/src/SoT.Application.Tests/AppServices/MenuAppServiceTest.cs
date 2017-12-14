using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Xunit;

namespace SoT.Application.Tests.AppServices
{
    public class MenuAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public MenuAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get by Claims")]
        [Trait(nameof(MenuItem), "App Service")]
        public void MenuItem_GetByClaims_Sucess()
        {
            // Arrange
            var claim = new Tuple<string, string>("AdmEverything", "True");
            var claims = new List<Tuple<string, string>>
            {
                claim
            };
            var menuItems = new Faker<MenuItem>()
                .CustomInstantiator(m => MenuItem.FactoryTest(
                    m.Internet.DomainName(),
                    m.Internet.DomainName(),
                    m.Internet.DomainName(),
                    m.Internet.Url(),
                    claim.Item1,
                    claim.Item2)).Generate(50000);

            mocker.Create<MenuAppService>();
            var menuAppService = mocker.Resolve<MenuAppService>();
            var menuService = mocker.GetMock<IMenuService>();
            menuService
                .Setup(c => c.GetAll())
                .Returns(menuItems);

            // Act
            var menuItemViewModels = menuAppService.GetByClaims(claims).ToList();

            // Assert
            menuService.Verify(c => c.GetAll(), Times.Once());
            for (int i = 0; i < menuItems.Count; i++)
            {
                Assert.Equal(menuItems[i].Name, menuItemViewModels[i].Name);
                Assert.Equal(menuItems[i].ActionName, menuItemViewModels[i].ActionName);
                Assert.Equal(menuItems[i].ControllerName, menuItemViewModels[i].ControllerName);
                Assert.Equal(menuItems[i].Url, menuItemViewModels[i].Url);
                Assert.Equal(menuItems[i].ClaimType, menuItemViewModels[i].ClaimType);
                Assert.Equal(menuItems[i].ClaimValue, menuItemViewModels[i].ClaimValue);
            }
        }
    }
}
