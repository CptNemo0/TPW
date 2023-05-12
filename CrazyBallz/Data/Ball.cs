﻿using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        private int postion_X;
        private int postion_Y;
        private readonly int radius;
        private int speed_X;
        private int speed_Y;
        private int stop_X;
        private int stop_Y;
        private Timer? timer;
        private Vector2 boardSize;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override int Position_X
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
        public override int Position_Y
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
        public override int Speed_X
        {
            get
            {
                lock(this) 
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
        public override int Speed_Y
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
        public override Timer? Timer { get => timer; set => timer = value; }
        public override Vector2 BoardSize { get => boardSize; set => boardSize = value; }
        public override int Stop_X { get => stop_X; set => stop_X = value; }
        public override int Stop_Y { get => stop_Y; set => stop_Y = value; }

        public Ball(int postion_X, int postion_Y, int radius, int speed_X, int speed_Y)
        {
            this.postion_X = postion_X;
            this.postion_Y = postion_Y;
            this.radius = radius;
            this.speed_X = speed_X;
            this.speed_Y = speed_Y;
            this.stop_X = 0;
            this.stop_Y = 0;
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

        private void SaveSpeeds()
        {
            stop_X = speed_X;
            stop_Y = speed_Y;
        }
        
        private void ResumeSpeeds()
        {
            speed_X = stop_X;
            speed_Y = stop_Y;
        }

        public override void BallStop()
        {
            SaveSpeeds();
            speed_X = 0;
            speed_Y = 0;
        }

        public override void BallGo()
        {
            ResumeSpeeds();
        }

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
