using System;

namespace MarsRoverKata.Core
{
    public class Coordinate
    {
        public Double X { get; set; }
        public Double Y { get; set; }

        public Coordinate(Double x, Double y)
        {
            X = x;
            Y = y;
        }
    }
}
