using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Data;

namespace Logic
{
    internal class BallManager : LogicApi
    {
        private readonly int boardWidth;
        private readonly int boardHeight;
        private DataApi repository;

        public override DataApi? Repository { get => repository; set => repository = value; }

        public override int BoardWitdth => boardWidth;

        public override int BoardHeight => boardHeight;

        public BallManager(int width, int height) 
        {
            boardWidth = width;
            boardHeight = height;
            Repository = DataApi.Instantiate();
        }

        public override IBall CreateBall(int x, int y, int radius, int xSpeed, int ySpeed)
        {
            if 
            (
                x > boardWidth - radius || xSpeed > boardWidth - radius || xSpeed < -1 * boardWidth + radius || 
                y > boardHeight - radius || ySpeed > boardHeight - radius || ySpeed < -1 * boardHeight + radius
            )
            {
                throw new ArgumentException("Ball was exceeding board range");
            }

            IBall ball = IBall.CreateBall(x, y, radius, xSpeed, ySpeed);
            Repository.AddBall(ball);
            return ball;
        }

        public override IBall CreateBallAtRandomCoordinates()
        {
            Random r = new();
            int maxRadius = 5;
            int maxSpeed = 3;
            return CreateBall(
                r.Next(maxRadius, boardWidth - maxRadius), 
                r.Next(maxRadius, boardHeight - maxRadius),
                r.Next(1, maxRadius), 
                r.Next(-maxSpeed, maxSpeed), 
                r.Next(-maxSpeed, maxSpeed)
            );
        }

        public override List<IBall> GetBallRepositoryList()
        {
            return Repository.Balls;
        }

        public override void RemoveAllBalls()
        {
            Repository.RemoveAllBalls();
        }

        public override int GetRepositroyListSize()
        {
            return Repository.GetAmountOfBalls();
        }
    }
}
