using System;

namespace MarsRoverKata.Core
{
    public class RoverController
    {
        private const Char Forward = 'f';
        private const Char Backward = 'b';
        private const Char Left = 'l';
        private const Char Right = 'r';

        private IRover rover;

        public RoverController(IRover rover)
        {
            this.rover = rover;
        }

        public void ProcessCommands(String commands)
        {
            foreach (var command in commands)
            {
                if (command == Forward)
                    rover.MoveForward();
                else if (command == Backward)
                    rover.MoveBackward();
                else if (command == Left)
                    rover.TurnLeft();
                else if (command == Right)
                    rover.TurnRight();

                if (rover.IsObstructed)
                    break;
            }
        }
    }
}
