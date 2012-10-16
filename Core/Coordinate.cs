using System;

namespace MarsRoverKata.Core
{
    public class Coordinate
    {
        public Double X { get; set; }
        public Double Y { get; set; }

        public Coordinate(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
    }
}
