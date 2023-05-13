using Data;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

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

        public override bool CreateBall(int x, int y, int radius, int xSpeed, int ySpeed, int mass)
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
            bool addable = true;
            foreach (IBall ballFromList in GetBallRepositoryList())
            {
                if (CalcDistance(ball, ballFromList) <= radius * 2) { addable = false; break; }
            }
            if (addable)
            {
                Repository.AddBall(ball);
            }
            return addable;
        }

        public override bool CreateBallAtRandomCoordinates()
        {
            Random r = new();

            int radius = 10;

            int[] speeds = { -3, -2, -1, 1, 2, 3 };
            int xSpeed = r.Next(0, 6);
            int ySpeed = r.Next(0, 6);
            int mass = r.Next(1, 11);
            if (ySpeed == 3 && xSpeed == 3)
            {
                ySpeed++;
            }
            return CreateBall(
                r.Next(radius, boardWidth - radius),
                r.Next(radius, boardHeight - radius),
                radius,
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

        public override async void StartBallsMovement()
        {
            Vector2 vector = new Vector2(boardWidth, boardHeight);
            foreach (IBall ball in GetBallRepositoryList())
            {
                ball.SetBoundries(vector);
            }

            while (true)
            {
                await Task.Run(() => { MoveTasks(); Thread.Sleep(16); Check(); });
            }

        }

        private async void MoveTasks()
        {
            Vector2 vector = new Vector2(boardWidth, boardHeight);
            foreach (IBall ball in GetBallRepositoryList())
            {
                await Task.Run(() =>
                {
                    ball.Move();
                });
            }
        }

        private float CalcDistance(IBall a, IBall b)
        {
            return (float)Math.Sqrt((a.Position_X - b.Position_X) * (a.Position_X - b.Position_X) + (a.Position_Y - b.Position_Y) * (a.Position_Y - b.Position_Y));
        }

        public void HandleCollision(IBall a, IBall b)
        {
            int Vx1, Vy1, Vx2, Vy2;

            Vx1 = (a.Mass * a.Speed_X + b.Mass * b.Speed_X - b.Mass * (a.Speed_X - b.Speed_X)) / (a.Mass + b.Mass);
            Vy1 = (a.Mass * a.Speed_Y + b.Mass * b.Speed_Y - b.Mass * (a.Speed_Y - b.Speed_Y)) / (a.Mass + b.Mass);
            Vx2 = (a.Mass * a.Speed_X + b.Mass * b.Speed_X - a.Mass * (b.Speed_X - a.Speed_X)) / (a.Mass + b.Mass);
            Vy2 = (a.Mass * a.Speed_Y + b.Mass * b.Speed_Y - a.Mass * (b.Speed_Y - a.Speed_Y)) / (a.Mass + b.Mass);

            a.ChangeXdirection();
            a.ChangeYdirection();
            a.Move();
            a.Speed_X = Vx1;
            a.Speed_Y = Vy1;

            b.ChangeXdirection();
            b.ChangeYdirection();
            b.Move();
            b.Speed_X = Vx2;
            b.Speed_Y = Vy2;
        }

        private void Check()
        {
            for (int i = 0; i < GetRepositroyListSize(); i++)
            {
                lock (GetBallRepositoryList()[i])
                {
                    for (int j = i + 1; j < GetRepositroyListSize(); j++)
                    {
                        lock (GetBallRepositoryList()[j])
                        {
                            if (CalcDistance(GetBallRepositoryList()[i], GetBallRepositoryList()[j]) <= 2 * GetBallRepositoryList()[i].Radius)
                            {
                                HandleCollision(GetBallRepositoryList()[i], GetBallRepositoryList()[j]);
                                /*
                                int x = GetBallRepositoryList()[i].Speed_X;
                                int y = GetBallRepositoryList()[i].Speed_Y;
                                GetBallRepositoryList()[i].ChangeXdirection();
                                GetBallRepositoryList()[i].ChangeYdirection();
                                GetBallRepositoryList()[i].Move();
                                GetBallRepositoryList()[i].Speed_X = GetBallRepositoryList()[j].Speed_X;
                                GetBallRepositoryList()[i].Speed_Y = GetBallRepositoryList()[j].Speed_Y;
                                GetBallRepositoryList()[j].ChangeXdirection();
                                GetBallRepositoryList()[j].ChangeYdirection();
                                GetBallRepositoryList()[j].Move();
                                GetBallRepositoryList()[j].Speed_X = x;
                                GetBallRepositoryList()[j].Speed_X = y;
                                */
                            }
                        }
                    }
                }

            }
        }

        public override void StopBallsMovement()
        {
            for (int i = 0; i < GetRepositroyListSize(); i++)
            {
                
            }
        }
    }
}
