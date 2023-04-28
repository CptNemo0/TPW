﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;

namespace Logic
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        private int postion_X;
        private int postion_Y;
        private readonly int radius;
        private int speed_X;
        private int speed_Y;
        private Timer? timer;
        //private Vector2 boardSize;
        private int mass;
        private int id;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override int Position_X 
        {
            get => postion_X;
            set { postion_X = value; NotifyPropertyChanged(); }
        }
        public override int Position_Y 
        {
            get => postion_Y;
            set { postion_Y = value; NotifyPropertyChanged(); }
        }
        public override int Radius
        {
            get => radius;
        }
        public override int Speed_X 
        {
            get => speed_X;
            set { speed_X = value; NotifyPropertyChanged(); }
        }
        public override int Speed_Y
        {
            get => speed_Y;
            set { speed_Y = value; NotifyPropertyChanged(); }
        }
        public override int Mass
        {
            get => mass;
            set { mass = value; NotifyPropertyChanged(); }
        }
        public override int Id { get => id; set => id = value; }
        //public override Timer? Timer { get => timer; set => timer = value; }
        //public override Vector2 BoardSize { get => boardSize; set => boardSize = value; }

        public Ball(int postion_X, int postion_Y, int radius, int speed_X, int speed_Y, int mass, int id)
        {
            this.postion_X = postion_X;
            this.postion_Y = postion_Y;
            this.radius = radius;
            this.speed_X = speed_X;
            this.speed_Y = speed_Y;
            this.mass = mass;
            this.id = id;
        }

        public override void ChangeXdirection()
        {
            Speed_X *= -1;
        }

        public override void ChangeYdirection()
        {
            Speed_Y *= -1;
        }
        /*
        public override void Move(object? obj)
        {
            Task.Run(() =>
            {
                while(_isMoving) 
                {
                    lock(lockObject)
                    {
                        if (obj == null) throw new ArgumentNullException("object is null");
                        if (obj is Vector2)
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
                        else
                        {
                            throw new ArgumentException("object was not a board class");
                        }
                    }
                    Thread.Sleep(16);
                }
            });
        }

        public override void StartMovement(Vector2 vector)
        {
            boardSize = vector;
            Timer = new Timer(Move, vector, 0, 16);
        }
        */
        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
