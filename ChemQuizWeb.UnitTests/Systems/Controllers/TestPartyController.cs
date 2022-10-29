using ChemQuizWeb.Controllers.API;
using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemQuizWeb.UnitTests.Systems.Controllers
{
    public class TestPartyController
    {
        [Fact]
        public async void Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockPartyService = new Mock<IPartyService>();
            mockPartyService
                .Setup(service => service.GetParties())
                .ReturnsAsync(PartyFixtures.GetTestParties());
            var controller = new PartiesController(mockPartyService.Object);
            //Act
            var result = (OkObjectResult) await controller.Get();
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void Get_OnSuccess_InvokesPartyServicesExactlyOnce()
        {
            //Arrange
            var mockPartyService = new Mock<IPartyService>();
            mockPartyService
                .Setup(service => service.GetParties())
                .ReturnsAsync(new List<Party>());
            var controller = new PartiesController(mockPartyService.Object);
            
            //Act
            var result = await controller.Get();
            
            //Assert
            mockPartyService
                .Verify(
                service => service.GetParties(),
                Times.Once()
            );
        }

        [Fact]
        public async void Get_OnSuccess_ReturnListOfParties()
        {
            //Arrange
            var mockPartyService = new Mock<IPartyService>();
            mockPartyService
                .Setup(service => service.GetParties())
                .ReturnsAsync(PartyFixtures.GetTestParties());
            var controller = new PartiesController(mockPartyService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Party>>();
        }

        [Fact]
        public async void Get_OnNoDataFound_ReturnsStatusCode404()
        {
            //Arrange
            var mockPartyService = new Mock<IPartyService>();
            mockPartyService
                .Setup(service => service.GetParties())
                .ReturnsAsync(new List<Party>());
            var controller = new PartiesController(mockPartyService.Object);
            //Act
            var result = await controller.Get();
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
