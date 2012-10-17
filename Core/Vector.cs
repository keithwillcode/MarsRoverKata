using System;

namespace MarsRoverKata.Core
{
    public class Vector
    {
        public static Vector Forward { get { return new Vector(0, 1); } }
        public static Vector Backward { get { return new Vector(0, -1); } }
        public static Vector Zero { get { return new Vector(0, 0); } }

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

        public override Int32 GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public static Vector GetUnitVectorFromAngle(Double degrees)
        {
            var rotationInRadians = (degrees * Math.PI) / 180;
            var x = Math.Round(Math.Cos(rotationInRadians), 8);
            var y = Math.Round(Math.Sin(rotationInRadians), 8);

            return new Vector(x, y);
        }

        public static Vector operator+(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }

        public static Vector operator*(Vector left, Double right)
        {
            return new Vector(left.X * right, left.Y * right);
        }
    }
}
