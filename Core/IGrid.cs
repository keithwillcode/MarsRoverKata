using System;

namespace MarsRoverKata.Core
{
    public interface IGrid
    {
        Coordinate GetAdjacentPosition(Coordinate position, UnitVector direction);
        Boolean IsObstacleInPosition(Coordinate coordinate);
    }
}
