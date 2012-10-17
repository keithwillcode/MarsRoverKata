using System;

namespace MarsRoverKata.Core
{
    public abstract class PhysicalObject
    {
        public Vector Forward { get; private set; }
        public Coordinate Position { get; protected set; }
        public Double Rotation { get; private set; }
        public Vector Velocity { get; protected set; }

        public PhysicalObject(Coordinate position, Double rotation, Vector velocity)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
            Forward = Vector.GetUnitVectorFromAngle(rotation);
        }

        protected abstract void Move();

        protected void ChangeVelocityBy(Int32 amount)
        {
            Velocity += Forward * amount;
        }

        protected void TurnBy(Double degrees)
        {
            Rotation = (Rotation + degrees) % 360;
            Forward = Vector.GetUnitVectorFromAngle(Rotation);
        }
    }
}
