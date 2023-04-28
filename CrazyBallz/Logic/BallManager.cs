using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private int radius;

        public override DataApi? Repository { get => repository; set => repository = value; }

        public override int BoardWitdth => boardWidth;

        public override int BoardHeight => boardHeight;

        public int Radius { get => radius; }

        public BallManager(int width, int height, int radius) 
        {
            this.boardWidth = width;
            this.boardHeight = height;
            this.radius = radius;
            Repository = DataApi.Instantiate();
        }

        public override IBall CreateBall(int x, int y, int radius, int xSpeed, int ySpeed, int mass)
        {
            if 
            (
                x < radius || x > boardWidth - radius || xSpeed > boardWidth - radius || xSpeed < -1 * boardWidth + radius || 
                y < radius || y > boardHeight - radius || ySpeed > boardHeight - radius || ySpeed < -1 * boardHeight + radius
            )
            {
                throw new ArgumentException("Ball was exceeding board range");
            }

            IBall ball = IBall.CreateBall(x, y, radius, xSpeed, ySpeed, mass);
            Repository.AddBall(ball);
            return ball;
        }

        public override IBall CreateBallAtRandomCoordinates()
        {
            Random r = new();
            int[] speeds = { -3, -2, -1, 0, 1, 2, 3 };
            int xSpeed = r.Next(0, 7);
            int ySpeed = r.Next(0, 7);
            int mass   = r.Next(1, 11);
            if(ySpeed == 3 && xSpeed == 3)
            {
                ySpeed++;
            }
            return CreateBall(
                r.Next(this.radius, boardWidth - this.radius), 
                r.Next(this.radius, boardHeight - this.radius),
                this.radius,
                speeds[xSpeed],
                speeds[ySpeed],
                mass
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

        public override void StartBallsMovement()
        {
            Vector2 vector = new Vector2(boardWidth, boardHeight);
            for (int i = 0; i< GetRepositroyListSize(); i++)
            {
                GetBallRepositoryList()[i].StartMovement(vector); 
            }
        }

        public override void StopBallsMovement()
        {
            for (int i = 0; i < GetRepositroyListSize(); i++)
            {
                if (GetBallRepositoryList()[i].Timer != null)
                {
                    GetBallRepositoryList()[i].Timer.Dispose();
                }
            }
        }
    }
}
