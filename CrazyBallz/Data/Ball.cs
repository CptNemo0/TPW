using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        private float postion_X;
        private float postion_Y;
        private readonly int radius;
        private float speed_X;
        private float speed_Y;
        private int mass;
        private Vector2 boardSize;

        public override event PropertyChangedEventHandler? PropertyChanged;

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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }
        public override Vector2 BoardSize { get => boardSize; set => boardSize = value; }
        public override int Mass
        {
            get => mass;
            set { mass = value; NotifyPropertyChanged(); }
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

        public override void ChangeXdirection()
        {
            Speed_X *= -1;
        }

        public override void ChangeYdirection()
        {
            Speed_Y *= -1;
        }

        public override void Move()
        {
            float boardWidth = boardSize[0];
            float boardHeight = boardSize[1];

            if (Position_X + Speed_X >= boardWidth - radius || Position_X + Speed_X <= radius)
            {
                ChangeXdirection();
            }
            if (Position_Y + Speed_Y >= boardHeight - radius || Position_Y + Speed_Y <= radius)
            {
                ChangeYdirection();
            }
            Position_X += Speed_X;
            Position_Y += Speed_Y;

        }

        public override void SetBoundries(Vector2 vector)
        {
            boardSize = vector;
        }

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
