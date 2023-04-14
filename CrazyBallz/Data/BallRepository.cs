using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class BallRepository : DataApi
    {
        private List<IBall> balls = new();

        public List<IBall> Balls { get => balls; set => balls = value; }

        public override void AddBall(IBall ball)
        {
            this.balls.Add(ball);
        }

        public override int GetAmountOfBalls()
        {
            return this.balls.Count;
        }

        public override void RemoveAllBalls()
        {
            this.balls.Clear();
        }

        public override void RemoveBall(IBall ball)
        {
            this.balls.Remove(ball);
        }
    }
}
