using System;
using System.Linq;
using MarsRoverKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class RoverTests
    {
        private Mock<IGrid> mockGrid;
        private Rover rover;
        private Coordinate startingPosition;
        private Double startingRotation;

        [TestInitialize]
        public void TestInitialize()
        {
            mockGrid = new Mock<IGrid>();
            startingPosition = new Coordinate(1, 2);
            startingRotation = DirectionRotations.North;

            rover = new Rover(startingPosition, startingRotation, mockGrid.Object);
        }

        [TestMethod]
        public void MoveForwardCallsCalculatePosition()
        {
            rover.MoveForward();
            mockGrid.Verify(m => m.GetAdjacentPosition(startingPosition, DirectionVectors.North), Times.Once());
        }

        [TestMethod]
        public void MoveForwardUpdatesRoverPosition()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<Vector>())).Returns(new Coordinate(30, 50));
            rover.MoveForward();

            Assert.AreEqual(30, rover.Position.X);
            Assert.AreEqual(50, rover.Position.Y);
        }

        [TestMethod]
        public void MoveBackwardCallsCalculatePosition()
        {
            rover.MoveBackward();
            mockGrid.Verify(m => m.GetAdjacentPosition(startingPosition, DirectionVectors.South), Times.Once());
        }

        [TestMethod]
        public void MoveBackwardUpdatesRoverPosition()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<Vector>())).Returns(new Coordinate(30, 50));
            rover.MoveBackward();

            Assert.AreEqual(30, rover.Position.X);
            Assert.AreEqual(50, rover.Position.Y);
        }

        [TestMethod]
        public void RoverDoesNotMoveForwardWhenObstacleIsInLocation()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<Vector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveForward();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
        }

        [TestMethod]
        public void RoverDoesNotMoveBackwardWhenObstacleIsInLocation()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<Vector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveBackward();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
        }

        [TestMethod]
        public void RoverRecordsObstacle()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<Vector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveForward();

            var obstacleCoordinates = rover.GetObstacleCoordinates();
            var firstCoordinate = obstacleCoordinates.First();

            Assert.AreEqual(1, obstacleCoordinates.Count());
            Assert.AreEqual(30, firstCoordinate.X);
            Assert.AreEqual(50, firstCoordinate.Y);
        }

        [TestMethod]
        public void TurnLeftIncreasesRotationByNinety()
        {
            rover = new Rover(startingPosition, DirectionRotations.North, mockGrid.Object);
            rover.TurnLeft();

            Assert.AreEqual(DirectionRotations.West, rover.Rotation);
        }

        [TestMethod]
        public void TurnRightDecreasesRotationByNinety()
        {
            rover = new Rover(startingPosition, DirectionRotations.North, mockGrid.Object);
            rover.TurnRight();

            Assert.AreEqual(DirectionRotations.East, rover.Rotation);
        }
    }
}
