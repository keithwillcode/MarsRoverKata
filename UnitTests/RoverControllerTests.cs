using System;
using MarsRoverKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class RoverControllerTests
    {
        private IGrid grid;
        private Mock<IRover> mockRover;
        private RoverController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            grid = new OneByOneGrid(4, 4);
            mockRover = new Mock<IRover>();
            controller = new RoverController(mockRover.Object);
        }

        [TestMethod]
        public void MovesRoverForwardWhenFCommandIsGiven()
        {
            controller.ProcessCommands("f");
            mockRover.Verify(m => m.MoveForward(), Times.Once());
        }

        [TestMethod]
        public void MovesRoverBackwardWhenBCommandIsGiven()
        {
            controller.ProcessCommands("b");
            mockRover.Verify(m => m.MoveBackward(), Times.Once());
        }

        [TestMethod]
        public void TurnsRoverLeftWhenLCommandIsGiven()
        {
            controller.ProcessCommands("l");
            mockRover.Verify(m => m.TurnLeft(), Times.Once());
        }

        [TestMethod]
        public void TurnsRoverLeftWhenRCommandIsGiven()
        {
            controller.ProcessCommands("r");
            mockRover.Verify(m => m.TurnRight(), Times.Once());
        }

        [TestMethod]
        public void RoverCanBeControlledWithMultipleCommands()
        {
            var commandsToSend = "ffbfrllrbb";
            var commandsPerformed = String.Empty;

            mockRover.Setup(m => m.MoveForward()).Callback(() => commandsPerformed += "f");
            mockRover.Setup(m => m.MoveBackward()).Callback(() => commandsPerformed += "b");
            mockRover.Setup(m => m.TurnLeft()).Callback(() => commandsPerformed += "l");
            mockRover.Setup(m => m.TurnRight()).Callback(() => commandsPerformed += "r");
            controller.ProcessCommands(commandsToSend);

            Assert.AreEqual(commandsToSend, commandsPerformed);
        }

        [TestMethod]
        public void RoverStopsMovingWhenAnObstacleIsEncountered()
        {
            var commandsToSend = "frb";
            var isObstructed = false;
            var commandsPerformed = String.Empty;

            mockRover.Setup(m => m.IsObstructed).Returns(() => isObstructed);
            mockRover.Setup(m => m.MoveForward()).Callback(() => commandsPerformed += "f");
            mockRover.Setup(m => m.MoveBackward()).Callback(() => isObstructed = true);
            mockRover.Setup(m => m.TurnRight()).Callback(() => commandsPerformed += "r");
            controller.ProcessCommands(commandsToSend);

            Assert.AreEqual("fr", commandsPerformed);
        }
    }
}
