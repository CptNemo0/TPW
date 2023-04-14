using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data
{
    internal class BallRepository : DataApi
    {
        private List<IBall> balls = new();

        public List<IBall> Balls { get => balls; set => balls = value; }

        public override void AddBall(IBall ball)
        {
            balls.Add(ball);
        }

        public override int GetAmountOfBalls()
        {
            return balls.Count;
        }

        public override void RemoveAllBalls()
        {
            balls.Clear();
        }

        public override void RemoveBall(IBall ball)
        {
            balls.Remove(ball);
        }
    }
}
