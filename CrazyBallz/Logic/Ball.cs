using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Ball : IBall
    {
        private int postion_X;
        private int postion_Y;
        private readonly int radius;
        private int speed_X;
        private int speed_Y;

        public override int Position_X 
        {
            get => postion_X;
            set => postion_X = value;
        }

        public override int Position_Y 
        {
            get => postion_Y;
            set => postion_Y = value;
        }

        public override int Radius
        {
            get => radius;
        }

        public override int Speed_X 
        {
            get => speed_X;
            set => speed_X = value;
        }

        public override int Speed_Y
        {
            get => speed_Y;
            set=> speed_Y = value;
        }

        public Ball(int postion_X, int postion_Y, int radius, int speed_X, int speed_Y)
        {
            this.postion_X = postion_X;
            this.postion_Y = postion_Y;
            this.radius = radius;
            this.speed_X = speed_X;
            this.speed_Y = speed_Y;
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
            postion_X += Speed_X;
            postion_Y += Speed_Y;
        }
    }
}
