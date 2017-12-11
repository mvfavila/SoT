﻿using AutoMoq;
using Moq;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using SoT.Domain.Tests.Shared;
using System;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class AdventureServiceTest
    {
        private readonly AutoMoqer mocker;

        public AdventureServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get Adventure and Address by Id")]
        [Trait("Adventure", "Domain Service")]
        public void Adventure_GetWithAddressById_Sucess()
        {
            // Arrange
            mocker.Create<AdventureService>();

            var adventureService = mocker.Resolve<AdventureService>();
            var adventureRepository = mocker.GetMock<IAdventureReadOnlyRepository>();

            // Act
            adventureService.GetWithAddressById(TestConstants.ADVENTURE_ID_VALID, TestConstants.USER_ID_VALID);

            // Assert
            adventureRepository.Verify(a => a.GetWithAddressById(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once());
        }
    }
}
