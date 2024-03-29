﻿using System.Net;
using Air.Controllers;
using Air.Interfaces;
using Air.Models;
using Air.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace Air.Tests.Controllers
{
    public class FlightManagementControllerTests
    {
        [Fact]
        public void CalculateJourney_Returns_OkResult()
        {
            // Arrange
            var origin = "MZL";
            var destination = "MAD";

            var mockFlightManagement = new Mock<IFlightManagement>();
                mockFlightManagement.Setup(fm => fm.CalculateJourney(origin, destination))
                    .Returns(new JourneyDto { Price = 800 });

                var controller = new FlightManagementController(mockFlightManagement.Object);

                // Act
                var result = controller.CalculateJourney(origin, destination);

                // Assert   
                Assert.IsType<HttpMessage<JourneyDto>>(result);
                var httpMessageResult = (HttpMessage<JourneyDto>)result;
                Assert.Equal(HttpStatusCode.OK, httpMessageResult.StatusCode);
            }

        [Fact]
        public void CalculateJourney_Returns_NoContentResult()
        {
            // Arrange
            var origin = "MZL";
            var destination = "POR";

            var mockFlightManagement = new Mock<IFlightManagement>();
            mockFlightManagement.Setup(fm => fm.CalculateJourney(origin, destination))
                .Returns((JourneyDto)null);

            var controller = new FlightManagementController(mockFlightManagement.Object);

            // Act
            var result = controller.CalculateJourney(origin, destination);

            // Assert
            Assert.IsType<HttpMessage<JourneyDto>>(result);
            var httpMessageResult = (HttpMessage<JourneyDto>)result;
            Assert.Equal(HttpStatusCode.NoContent, httpMessageResult.StatusCode);
        }
    }
}