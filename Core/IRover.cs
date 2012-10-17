using System;
using System.Collections.Generic;

namespace MarsRoverKata.Core
{
    public interface IRover : IPhysicalObject
    {
        IEnumerable<Coordinate> GetObstacleCoordinates();
        void MoveBackward();
        void MoveForward();
        void TurnLeft();
        void TurnRight();
        Boolean IsObstructed { get; }
    }
}
