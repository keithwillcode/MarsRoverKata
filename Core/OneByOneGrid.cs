using System;
using System.Collections.Generic;

namespace MarsRoverKata.Core
{
    public class OneByOneGrid : IGrid
    {
        private Int32 numberOfRows;
        private Int32 numberOfColumns;
        private HashSet<Coordinate> obstacleCoordinates;

        public OneByOneGrid(Int32 numberOfRows, Int32 numberOfColumns)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public Coordinate GetAdjacentPosition(Coordinate position, UnitVector direction)
        {
            position.X = BindValue(position.X + direction.X, 0, numberOfColumns - 1);
            position.Y = BindValue(position.Y + direction.Y, 0, numberOfRows - 1);

            return position;
        }

        private Double BindValue(Double value, Double min, Double max)
        {
            if (value < min)
                return max;
            else if (value > max)
                return min;

            return value;
        }

        public void AddObstacle(Coordinate coordinate)
        {
            obstacleCoordinates.Add(coordinate);
        }

        public Boolean IsObstacleInPosition(Coordinate coordinate)
        {
            return obstacleCoordinates.Contains(coordinate);
        }
    }
}
