using System;

namespace MarsRoverKata.Core
{
    public class Vector
    {
        public Double X { get; set; }
        public Double Y { get; set; }

        public Vector(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public override Boolean Equals(Object obj)
        {
            var unitVector = (Vector)obj;
            return unitVector.X == X && unitVector.Y == Y;
        }

        public static Vector GetUnitVectorFromRotation(Double degrees)
        {
            var rotationInRadians = (degrees * Math.PI) / 180;
            var x = Math.Round(Math.Cos(rotationInRadians), 8);
            var y = Math.Round(Math.Sin(rotationInRadians), 8);

            return new Vector(x, y);
        }
    }
}
