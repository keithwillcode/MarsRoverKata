using System;

namespace MarsRoverKata.Core
{
    public interface IPhysicalObject
    {
        Coordinate Position { get; }
        Double Rotation { get; }
        Vector Velocity { get; }
    }
}
