using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverKata.Core
{
    public class Rover
    {
        public Coordinate Position { get; private set; }
        public Direction Direction { get; private set; }
        private IGrid grid;
        private HashSet<Coordinate> obstacleCoordinates;

        public Rover(Coordinate startingPosition, Direction startingDirection, IGrid grid)
        {
            this.Position = startingPosition;
            this.Direction = startingDirection;
            this.grid = grid;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public void MoveForward()
        {
            HandleMovement(Movement.Forward);
        }

        public void MoveBackward()
        {
            HandleMovement(Movement.Backward);
        }

        private void HandleMovement(Movement movement)
        {
            var adjacentPosition = grid.GetAdjacentPosition(Position, Direction, movement);

            if (grid.IsObstacleInPosition(adjacentPosition))
                obstacleCoordinates.Add(adjacentPosition);
            else
                Position = adjacentPosition;
        }

        public void TurnLeft()
        {
            if (Direction == Direction.North)
                Direction = Direction.West;
            else if (Direction == Core.Direction.West)
                Direction = Direction.South;
            else if (Direction == Core.Direction.South)
                Direction = Direction.East;
            else if (Direction == Core.Direction.East)
                Direction = Direction.North;
        }

        public void TurnRight()
        {
            if (Direction == Direction.North)
                Direction = Direction.East;
            else if (Direction == Core.Direction.West)
                Direction = Direction.North;
            else if (Direction == Core.Direction.South)
                Direction = Direction.West;
            else if (Direction == Core.Direction.East)
                Direction = Direction.South;
        }

        public IEnumerable<Coordinate> GetObstacleCoordinates()
        {
            return obstacleCoordinates.ToList();
        }
    }
}
