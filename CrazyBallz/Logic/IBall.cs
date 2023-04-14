using System;
using System.Numerics;
using System.Threading;

namespace Logic
{
    public abstract class IBall
    {
        public abstract int Position_X { get; set; }
        public abstract int Position_Y { get; set; }
        public abstract int Radius { get; }
        public abstract int Speed_X { get; set; }
        public abstract int Speed_Y { get; set; }
        public abstract Timer? Timer { get; set; }

        public static IBall CreateBall(int postion_X, int postion_Y, int radius, int speed_X, int speed_Y)
        {
            return new Ball(postion_X, postion_Y, radius, speed_X, speed_Y);
        }

        public abstract void ChangeXdirection();
        public abstract void ChangeYdirection();
        public abstract void Move(object? obj);
        public abstract void StartMovement(Board board);
    }
}
