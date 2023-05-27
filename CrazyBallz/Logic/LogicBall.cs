using Data;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    internal class LogicBall : ILogicBall, INotifyPropertyChanged
    {
        private readonly IBall ball;

        public override float Position_X
        {
            get
            {
                lock (this)
                {
                    return ball.Position_X;
                }
            }
            set
            {
                lock (this)
                {
                    ball.Position_X = value;
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
                    return ball.Position_Y;
                }
            }
            set
            {
                lock (this)
                {
                    ball.Position_Y = value;
                }
                NotifyPropertyChanged();
            }
        }
        public override int Radius
        {
            get => ball.Radius;
        }
        public override float Speed_X
        {
            get
            {
                lock (this)
                {
                    return ball.Speed_X;
                }
            }
            set
            {
                lock (this)
                {
                    ball.Speed_X = value;
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
                    return ball.Speed_Y;
                }
            }
            set
            {
                lock (this)
                {
                    ball.Speed_Y = value;
                }
                NotifyPropertyChanged();
            }
        }
        public override Vector2 BoardSize { get => ball.BoardSize; set => ball.BoardSize = value; }
        public override int Mass
        {
            get => ball.Mass;
            set { ball.Mass = value; }
        }
        public override event PropertyChangedEventHandler? PropertyChanged;

        public LogicBall(IBall ball)
        {
            this.ball = ball;
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
            float boardWidth = BoardSize[0];
            float boardHeight = BoardSize[1];

            if (Position_X + Speed_X >= boardWidth - Radius || Position_X + Speed_X <= Radius)
            {
                ChangeXdirection();
            }
            if (Position_Y + Speed_Y >= boardHeight - Radius || Position_Y + Speed_Y <= Radius)
            {
                ChangeYdirection();
            }
            Position_X += Speed_X;
            Position_Y += Speed_Y;
        }

        public override void SetBoundries(Vector2 vector)
        {
            BoardSize = vector;
        }

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
