using System.ComponentModel;
using System.Numerics;

namespace Data
{
    public abstract class IBall
    {
        public abstract int Position_X { get; set; }
        public abstract int Position_Y { get; set; }
        public abstract int Radius { get; }
        public abstract int Speed_X { get; set; }
        public abstract int Speed_Y { get; set; }
        public abstract int Stop_X { get; set; }
        public abstract int Stop_Y { get; set; }
        public abstract int Mass { get; set; }
        public abstract Timer? Timer { get; set; }
        public abstract Vector2 BoardSize { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static IBall CreateBall(int postion_X, int postion_Y, int radius, int speed_X, int speed_Y, int mass)
        {
            return new Ball(postion_X, postion_Y, radius, speed_X, speed_Y, mass);
        }

        public abstract void ChangeXdirection();
        public abstract void ChangeYdirection();
        public abstract void Move();
        public abstract void SetBoundries(Vector2 vector);
        public abstract void BallStop();
        public abstract void BallGo();
    }
}
