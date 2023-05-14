using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        private readonly IBall ball;
        public event PropertyChangedEventHandler? PropertyChanged;

        public float Position_X
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
        public float Position_Y
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
        public int Radius
        {
            get => ball.Radius;
        }
        public float Speed_X
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
        public float Speed_Y
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
        public Vector2 BoardSize { get => ball.BoardSize; set => ball.BoardSize = value; }
        public int Mass
        {
            get => ball.Mass;
            set { ball.Mass = value; }
        }

        public LogicBall(IBall ball)
        {
            this.ball = ball;
        }

        public void ChangeXdirection()
        {
            Speed_X *= -1;
        }

        public void ChangeYdirection()
        {
            Speed_Y *= -1;
        }

        public void Move()
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

        public void SetBoundries(Vector2 vector)
        {
            BoardSize = vector;
        }

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
