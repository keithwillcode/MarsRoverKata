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
        private UnitVector startingDirection;

        [TestInitialize]
        public void TestInitialize()
        {
            mockGrid = new Mock<IGrid>();
            startingPosition = new Coordinate(1, 2);
            startingDirection = Direction.North;

            rover = new Rover(startingPosition, startingDirection, mockGrid.Object);
        }

        [TestMethod]
        public void MoveForwardCallsCalculatePosition()
        {
            rover.MoveForward();
            mockGrid.Verify(m => m.GetAdjacentPosition(startingPosition, startingDirection), Times.Once());
        }

        [TestMethod]
        public void MoveForwardUpdatesRoverPosition()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<UnitVector>())).Returns(new Coordinate(30, 50));
            rover.MoveForward();

            Assert.AreEqual(30, rover.Position.X);
            Assert.AreEqual(50, rover.Position.Y);
        }

        [TestMethod]
        public void MoveBackwardCallsCalculatePosition()
        {
            rover.MoveBackward();
            mockGrid.Verify(m => m.GetAdjacentPosition(startingPosition, startingDirection), Times.Once());
        }

        [TestMethod]
        public void MoveBackwardUpdatesRoverPosition()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<UnitVector>())).Returns(new Coordinate(30, 50));
            rover.MoveBackward();

            Assert.AreEqual(30, rover.Position.X);
            Assert.AreEqual(50, rover.Position.Y);
        }

        [TestMethod]
        public void RoverDoesNotMoveForwardWhenObstacleIsInLocation()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<UnitVector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveForward();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
        }

        [TestMethod]
        public void RoverDoesNotMoveBackwardWhenObstacleIsInLocation()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<UnitVector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveBackward();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
        }

        [TestMethod]
        public void RoverRecordsObstacle()
        {
            mockGrid.Setup(m => m.GetAdjacentPosition(It.IsAny<Coordinate>(), It.IsAny<UnitVector>())).Returns(new Coordinate(30, 50));
            mockGrid.Setup(m => m.IsObstacleInPosition(It.IsAny<Coordinate>())).Returns(true);
            rover.MoveForward();

            var obstacleCoordinates = rover.GetObstacleCoordinates();
            var firstCoordinate = obstacleCoordinates.First();

            Assert.AreEqual(1, obstacleCoordinates.Count());
            Assert.AreEqual(30, firstCoordinate.X);
            Assert.AreEqual(50, firstCoordinate.Y);
        }

        [TestMethod]
        public void TurnLeftWhenFacingNorthSetsDirectionToWest()
        {
            rover = new Rover(startingPosition, Direction.North, mockGrid.Object);
            rover.TurnLeft();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void TurnLeftWhenFacingWestSetsDirectionToSouth()
        {
            rover = new Rover(startingPosition, Direction.West, mockGrid.Object);
            rover.TurnLeft();

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void TurnLeftWhenFacingSouthSetsDirectionToEast()
        {
            rover = new Rover(startingPosition, Direction.South, mockGrid.Object);
            rover.TurnLeft();

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void TurnLeftWhenFacingEastSetsDirectionToNorth()
        {
            rover = new Rover(startingPosition, Direction.East, mockGrid.Object);
            rover.TurnLeft();

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void TurnRightWhenFacingNorthSetsDirectionToEast()
        {
            rover = new Rover(startingPosition, Direction.North, mockGrid.Object);
            rover.TurnRight();

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void TurnRightWhenFacingWestSetsDirectionToNorth()
        {
            rover = new Rover(startingPosition, Direction.West, mockGrid.Object);
            rover.TurnRight();

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void TurnRightWhenFacingSouthSetsDirectionToWest()
        {
            rover = new Rover(startingPosition, Direction.South, mockGrid.Object);
            rover.TurnRight();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void TurnRightWhenFacingEastSetsDirectionToSouth()
        {
            rover = new Rover(startingPosition, Direction.East, mockGrid.Object);
            rover.TurnRight();

            Assert.AreEqual(Direction.South, rover.Direction);
        }
    }
}
