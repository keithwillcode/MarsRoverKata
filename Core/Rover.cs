using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata.Core
{
    public class Rover : IRover
    {
        public Boolean IsObstructed { get; private set; }
        public Coordinate Position { get; private set; }
        public Double Rotation { get; private set; }
        public Vector Velocity { get; private set; }

        private Vector forward;
        private IGrid grid;
        private HashSet<Coordinate> obstacleCoordinates;

        public Rover(Coordinate position, Double rotation, IGrid grid)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Velocity = new Vector(0, 0);
            this.forward = Vector.GetUnitVectorFromAngle(rotation);
            this.grid = grid;
            this.obstacleCoordinates = new HashSet<Coordinate>();
        }

        public void MoveForward()
        {
            UpdateVelocity(Vector.Forward);
            Move();
        }

        public void MoveBackward()
        {
            UpdateVelocity(Vector.Backward);
            Move();
        }

        private void UpdateVelocity(Vector changeInVelocity)
        {
            Velocity = Vector.Add(Velocity, changeInVelocity);
        }

        private void Move()
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
        }        

        public void TurnLeft()
        {
            TurnBy(90);
        }

        public void TurnRight()
        {
            TurnBy(-90);
        }

        private void TurnBy(Double degrees)
        {
            Rotation = (Rotation + degrees) % 360;
            forward = Vector.GetUnitVectorFromAngle(Rotation);
        }

        public IEnumerable<Coordinate> GetObstacleCoordinates()
        {
            return obstacleCoordinates.ToList();
        }
    }
}
