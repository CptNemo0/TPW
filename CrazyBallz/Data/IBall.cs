using System.ComponentModel;
using System.Numerics;

namespace Data
{
    public abstract class IBall
    {
        public abstract float Position_X { get; set; }
        public abstract float Position_Y { get; set; }
        public abstract int Radius { get; }
        public abstract float Speed_X { get; set; }
        public abstract float Speed_Y { get; set; }
        public abstract int Mass { get; set; }
        public abstract Vector2 BoardSize { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static IBall CreateBall(float postion_X, float postion_Y, int radius, float speed_X, float speed_Y, int mass)
        {
            return new Ball(postion_X, postion_Y, radius, speed_X, speed_Y, mass);
        }

        public abstract void ChangeXdirection();
        public abstract void ChangeYdirection();
        public abstract void Move();
        public abstract void SetBoundries(Vector2 vector);
    }
}
