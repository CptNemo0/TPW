using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball
    {
        private int x;
        private int y;
        private int radius;
        private int velocity;

        public Ball(int x, int y, int radius, int velocity)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Velocity = velocity;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Radius { get => radius; set => radius = value; }
        public int Velocity { get => velocity; set => velocity = value; }
    
        public Vector2 getPosition()
        {
            return new Vector2(X, Y);
        }
    }
}
