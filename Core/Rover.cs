using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata.Core
{
    public class Rover : PhysicalObject, IRover
    {
        public Boolean IsObstructed { get; private set; }

        private IGrid grid;
        private HashSet<Coordinate> obstacleCoordinates;

        public Rover(Coordinate position, Double rotation, IGrid grid) 
            : base(position, rotation, Vector.Zero)
        {
            this.grid = grid;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public void MoveForward()
        {
            ChangeVelocityBy(1);
            Move();
        }

        public void MoveBackward()
        {
            ChangeVelocityBy(-1);
            Move();
        }

        protected override void Move()
        {
            var adjacentPosition = grid.GetAdjacentPosition(Position, Velocity);

            if (grid.IsObstacleInPosition(adjacentPosition))
            {
                obstacleCoordinates.Add(adjacentPosition);
                IsObstructed = true;
            }
            else
            {
                Position = adjacentPosition;
            }

            Velocity = Vector.Zero;
        }        

        public void TurnLeft()
        {
            TurnBy(90);
        }

        public void TurnRight()
        {
            TurnBy(-90);
        }

        public IEnumerable<Coordinate> GetObstacleCoordinates()
        {
            return obstacleCoordinates.ToList();
        }
    }
}
