using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    public abstract class LogicApi
    {
        public DataApi? Repository;

        public static LogicApi Instantiate(int boardHeight, int boardWidth)
        {
            return new BallManager(boardHeight, boardWidth, DataApi.Instantiate());
        }

        public abstract IBall CreateBall(int x, int y, int radius, int xSpeed, int ySpeed);

        public abstract IBall CreateBallAtRandomCoordinates();

        public abstract void RemoveAllBalls();

        public abstract List<IBall> GetBallRepositoryList();
    }
}
