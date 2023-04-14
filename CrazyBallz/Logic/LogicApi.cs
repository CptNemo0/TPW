using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Data;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract DataApi? Repository { get; set; }
        public abstract int BoardWitdth { get; }
        public abstract int BoardHeight { get; }

        public static LogicApi Instantiate(int boardHeight, int boardWidth)
        {
            return new BallManager(boardHeight, boardWidth);
        }

        public abstract IBall CreateBall(int x, int y, int radius, int xSpeed, int ySpeed);

        public abstract IBall CreateBallAtRandomCoordinates();

        public abstract void RemoveAllBalls();

        public abstract List<IBall> GetBallRepositoryList();

        public abstract int GetRepositroyListSize();

        public abstract void StartBallsMovement();
    }
}
