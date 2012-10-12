using System;
using System.Collections.Generic;

namespace MarsRoverKata.Core
{
    public class Grid : IGrid
    {
        private Int32 numberOfRows;
        private Int32 numberOfColumns;
        private HashSet<Coordinate> obstacleCoordinates;

        public Grid(Int32 numberOfRows, Int32 numberOfColumns)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public Coordinate GetAdjacentPosition(Coordinate position, Direction direction, Movement movement)
        {
            if (movement == Movement.Forward)
            {
                if (direction == Direction.North)
                    position.Y -= 1;
                else if (direction == Direction.South)
                    position.Y += 1;
                else if (direction == Direction.East)
                    position.X += 1;
                else if (direction == Direction.West)
                    position.X -= 1;
            }
            else if (movement == Movement.Backward)
            {
                if (direction == Direction.North)
                    position.Y += 1;
                else if (direction == Direction.South)
                    position.Y -= 1;
                else if (direction == Direction.East)
                    position.X -= 1;
                else if (direction == Direction.West)
                    position.X += 1;                
            }

            position.X = BindValue(position.X, 0, numberOfColumns - 1);
            position.Y = BindValue(position.Y, 0, numberOfRows - 1);

            return position;
        }

        private Int32 BindValue(Int32 value, Int32 min, Int32 max)
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
