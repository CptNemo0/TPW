using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class ILogicBall
    {
        public abstract float Position_X { get; set; }
        public abstract float Position_Y { get; set; }
        public abstract int Radius { get; }
        public abstract float Speed_X { get; set; }
        public abstract float Speed_Y { get; set; }
        public abstract int Mass { get; set; }
        public abstract Vector2 BoardSize { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static ILogicBall Instantiate(IBall ball)
        {
            return new LogicBall(ball);
        }

        public abstract void ChangeXdirection();
        public abstract void ChangeYdirection();
        public abstract void Move();
        public abstract void SetBoundries(Vector2 vector);
    }
}
