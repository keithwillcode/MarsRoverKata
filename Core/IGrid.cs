using System;

namespace MarsRoverKata.Core
{
    public interface IGrid
    {
        void AddObstacle(Coordinate position);
        Coordinate GetAdjacentPosition(Coordinate position, Vector velocity);
        Boolean IsObstacleInPosition(Coordinate position);
    }
}
