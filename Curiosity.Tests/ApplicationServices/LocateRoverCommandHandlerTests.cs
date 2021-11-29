using Moq;
using Xunit;
using Curiosity.Domain.Model;
using Curiosity.Domain.Manager;
using Curiosity.Application.Command;
using System;

namespace Curiosity.Tests.ApplicationServices
{
    public class LocateRoverCommandHandlerTests
    {
        public LocateRoverCommandHandlerTests()
        {
            
        }

        [Fact]
        public void WhenThePositionIsOccupiedByAnotherRover_ThrowException()
        {
            Mock<IPlateauManager> mockPlateauManager = new();
            mockPlateauManager
                .Setup(x => x.TryPutRover(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Directions>()))
                .Returns(false);

            var command = new LocateRoverCommandHandler(mockPlateauManager.Object);
            Assert.Throws<Exception>(() => command.Handle(new LocateRoverCommand()));
        }
    }
}