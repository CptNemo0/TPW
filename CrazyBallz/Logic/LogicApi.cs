using Data;
using System.Collections.Generic;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract DataApi Repository { get; set; }
        public abstract int BoardWitdth { get; }
        public abstract int BoardHeight { get; }
        
        public abstract LoggingApi JsonLogger { get; }
        public abstract List<ILogicBall> LogicBalls { get; set; }

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

        public abstract void StartLogging();
        public abstract float CalcDistance(ILogicBall a, ILogicBall b);

        public abstract void HandleCollision(ILogicBall a, ILogicBall b);
    }
}
