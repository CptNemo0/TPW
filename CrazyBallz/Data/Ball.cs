using System.Numerics;

namespace Data
{
    internal class Ball : IBall
    {
        private float postion_X;
        private float postion_Y;
        private readonly int radius;
        private float speed_X;
        private float speed_Y;
        private int mass;
        private Vector2 boardSize;

        public override float Position_X
        {
            get
            {
                lock (this)
                {
                    return postion_X;
                }
            }
            set
            {
                lock (this)
                {
                    postion_X = value;
                }
            }
        }
        public override float Position_Y
        {
            get
            {
                lock (this)
                {
                    return postion_Y;
                }
            }
            set
            {
                lock (this)
                {
                    postion_Y = value;
                }

            }
        }
        public override int Radius
        {
            get => radius;
        }
        public override float Speed_X
        {
            get
            {
                lock (this)
                {
                    return speed_X;
                }
            }
            set
            {
                lock (this)
                {
                    speed_X = value;
                }
            }
        }
        public override float Speed_Y
        {
            get
            {
                lock (this)
                {
                    return speed_Y;
                }
            }
            set
            {
                lock (this)
                {
                    speed_Y = value;
                }
            }
        }
        public override Vector2 BoardSize { get => boardSize; set => boardSize = value; }
        public override int Mass
        {
            get => mass;
            set { mass = value; }
        }
        public Ball(float postion_X, float postion_Y, int radius, float speed_X, float speed_Y, int mass)
        {
            this.postion_X = postion_X;
            this.postion_Y = postion_Y;
            this.radius = radius;
            this.speed_X = speed_X;
            this.speed_Y = speed_Y;
            this.mass = mass;
        }
    }
}
