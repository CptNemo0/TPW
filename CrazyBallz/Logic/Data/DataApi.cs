using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Logic.Data
{
    public abstract class DataApi
    {
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
