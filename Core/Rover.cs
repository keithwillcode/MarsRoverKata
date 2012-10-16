using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverKata.Core
{
    public class Rover : IRover
    {
        public Coordinate Position { get; private set; }
        public UnitVector Direction { get; private set; }
        private IGrid grid;
        private HashSet<Coordinate> obstacleCoordinates;

        public Rover(Coordinate startingPosition, UnitVector startingDirection, IGrid grid)
        {
            this.Position = startingPosition;
            this.Direction = startingDirection;
            this.grid = grid;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public void MoveForward()
        {
            HandleMovement(Direction);
        }

        public void MoveBackward()
        {
            var backwardDirection = Direction.Invert();
            HandleMovement(backwardDirection);
        }

        private void HandleMovement(UnitVector direction)
        {
            var adjacentPosition = grid.GetAdjacentPosition(Position, Direction);

            if (grid.IsObstacleInPosition(adjacentPosition))
                obstacleCoordinates.Add(adjacentPosition);
            else
                Position = adjacentPosition;
        }

        public void TurnLeft()
        {
            Direction = Direction.Rotate(90);
        }

        public void TurnRight()
        {
            Direction = Direction.Rotate(-90);
        }

        public IEnumerable<Coordinate> GetObstacleCoordinates()
        {
            return obstacleCoordinates.ToList();
        }
    }
}
