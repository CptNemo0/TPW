using Data;
using System.Collections.Generic;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract DataApi Repository { get; set; }
        public abstract int BoardWitdth { get; }
        public abstract int BoardHeight { get; }
        public abstract Logger JsonLogger { get; set; }
        public abstract List<LogicBall> LogicBalls { get; set; }

        public static LogicApi Instantiate(int boardHeight, int boardWidth)
        {
            return new BallManager(boardHeight, boardWidth);
        }

        public abstract bool CreateBall(int x, int y, int radius, int xSpeed, int ySpeed, int mass);

        public abstract bool CreateBallAtRandomCoordinates();

        public abstract void RemoveAllBalls();

        public abstract List<IBall> GetBallRepositoryList();

        public abstract int GetRepositroyListSize();

        public abstract void StartBallsMovement();

        public abstract void StopBallsMovement();

        public abstract float CalcDistance(LogicBall a, LogicBall b);

        public abstract void HandleCollision(LogicBall a, LogicBall b);
    }
}
