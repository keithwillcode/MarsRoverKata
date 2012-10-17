using System;

namespace MarsRoverKata.Core
{
    public interface IPhysicalObject
    {
        Vector Forward { get; }
        Coordinate Position { get; }
        Double Rotation { get; }
        Vector Velocity { get; }
    }
}
