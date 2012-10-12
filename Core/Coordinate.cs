using System;

namespace MarsRoverKata.Core
{
    public class Coordinate
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Coordinate(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
    }
}
