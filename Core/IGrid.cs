using System;

namespace MarsRoverKata.Core
{
    public interface IGrid
    {
        Coordinate GetAdjacentPosition(Coordinate position, Direction direction, Movement movement);
        Boolean IsObstacleInPosition(Coordinate coordinate);
    }
}
