using System;
using MarsRoverKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class OneByOneGridTests
    {
        private const Int32 NumberOfRows = 100;
        private const Int32 NumberOfColumns = 100;
        private const Int32 MaximumX = NumberOfRows - 1;
        private const Int32 MaximumY = NumberOfColumns - 1;

        private OneByOneGrid grid;

        [TestInitialize]
        public void TestInitialize()
        {
            grid = new OneByOneGrid(NumberOfRows, NumberOfColumns);
        }

        [TestMethod]
        public void CalculateNewPositionWrapsToBottom()
        {
            var startingPosition = new Coordinate(0, MaximumY);
            var position = grid.GetAdjacentPosition(startingPosition, DirectionUnitVectors.North);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionWrapsToRight()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, DirectionUnitVectors.West);

            Assert.AreEqual(MaximumX, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionWrapsToTop()
        {
            var startingPosition = new Coordinate(0, 0);
            var position = grid.GetAdjacentPosition(startingPosition, DirectionUnitVectors.South);

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(MaximumX, position.Y);
        }

        [TestMethod]
        public void CalculateNewPositionWrapsToLeft()
        {
            var startingPosition = new Coordinate(MaximumX, 0);
            var position = grid.GetAdjacentPosition(startingPosition, DirectionUnitVectors.East);

            Assert.AreEqual(0, position.X);
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
