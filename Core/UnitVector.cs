using System;

namespace MarsRoverKata.Core
{
    public class UnitVector
    {
        public Double X { get; set; }
        public Double Y { get; set; }

        public UnitVector(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public UnitVector Rotate(Int32 degrees)
        {
            var currentAngle = Math.Atan2(Y, X);
            var newAngle = currentAngle + (degrees * Math.PI) / 180;
            var x = Math.Round(Math.Cos(newAngle), 8);
            var y = Math.Round(Math.Sin(newAngle), 8);

            return new UnitVector(x, y);
        }

        public UnitVector Invert()
        {
            return new UnitVector(X * -1, Y * -1);
        }

        public override Boolean Equals(Object obj)
        {
            var unitVector = (UnitVector)obj;
            return unitVector.X == X && unitVector.Y == Y;
        }
    }
}
