namespace MarsRoverKata.Core
{
    public class Direction
    {
        public static readonly UnitVector North = new UnitVector(0, 1);
        public static readonly UnitVector South = new UnitVector(0, -1);
        public static readonly UnitVector East = new UnitVector(1, 0);
        public static readonly UnitVector West = new UnitVector(-1, 0);
    }
}
