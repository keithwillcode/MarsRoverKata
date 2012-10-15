using System;
using System.Collections.Generic;

namespace MarsRoverKata.Core
{
    public interface IRover
    {
        Direction Direction { get; }
        IEnumerable<Coordinate> GetObstacleCoordinates();
        void MoveBackward();
        void MoveForward();
        Coordinate Position { get; }
        void TurnLeft();
        void TurnRight();
    }
}
