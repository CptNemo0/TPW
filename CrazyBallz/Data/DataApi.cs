using System;
using System.Collections.Generic;

namespace Logic.Data
{
    public abstract class DataApi
    {
        public abstract List<IBall>? Balls { get; }
        public static DataApi Instantiate()
        {
            return new BallRepository();
        }
        public abstract void RemoveAllBalls();
        public abstract int GetAmountOfBalls();
        public abstract void AddBall(IBall ball);
        public abstract void RemoveBall(IBall ball);
    }
}
