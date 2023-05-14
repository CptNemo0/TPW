namespace Data
{
    public class BallRepository : DataApi
    {
        private List<IBall> balls = new();

        public override List<IBall>? Balls
        {
            get => balls;
        }

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
