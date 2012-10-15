using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverKata.Core;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class GridTests
    {
        private const Int32 NumberOfRows = 100;
        private const Int32 NumberOfColumns = 100;
        private const Int32 MaxRowIndex = NumberOfRows - 1;
        private const Int32 MaxColumnIndex = NumberOfColumns - 1;

        private OneByOneGrid grid;

        [TestInitialize]
        public void TestInitialize()
        {
            grid = new OneByOneGrid(NumberOfRows, NumberOfColumns);
        }

        [TestMethod]
        public void CalculateNewPositionFacingNorthWrapsToBottomWhenMovingForward()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.North, Movement.Forward);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(MaxColumnIndex, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingWestWrapsToRightWhenMovingForward()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.West, Movement.Forward);

            Assert.AreEqual(MaxRowIndex, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingSouthWrapsToTopWhenMovingForward()
        {
            var startingPosition = new Coordinate(MaxRowIndex, MaxColumnIndex);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.South, Movement.Forward);

            Assert.AreEqual(MaxRowIndex, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingEastWrapsToLeftWhenMovingForward()
        {
            var startingPosition = new Coordinate(MaxRowIndex, MaxColumnIndex);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.East, Movement.Forward);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(MaxColumnIndex, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingNorthWrapsToTopWhenMovingBackward()
        {
            var startingPosition = new Coordinate(0, MaxColumnIndex);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.North, Movement.Backward);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingWestWrapsToLeftWhenMovingBackward()
        {
            var startingPosition = new Coordinate(MaxRowIndex, 0);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.West, Movement.Backward);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingSouthWrapsToBottomWhenMovingBackward()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.South, Movement.Backward);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(MaxColumnIndex, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionFacingEastWrapsToRightWhenMovingBackward()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, Direction.East, Movement.Backward);

            Assert.AreEqual(MaxRowIndex, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void IsObstacleInPositionReturnsTrueWhenObstacleIsSet()
        {
            var obstacleCoordinate = new Coordinate(30, 50);
            grid.AddObstacle(obstacleCoordinate);

            Assert.IsTrue(grid.IsObstacleInPosition(obstacleCoordinate));
        }

        [TestMethod]
        public void IsObstacleInPositionReturnsFalseWhenObstacleIsNotSet()
        {
            var obstacleCoordinate = new Coordinate(30, 50);
            grid.AddObstacle(obstacleCoordinate);

            Assert.IsFalse(grid.IsObstacleInPosition(new Coordinate(20, 50)));
        }
    }
}
