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
        private bool flag = false;
        private List<ILogicBall> logicBalls = new();
        private LoggingApi? jsonLogger;

        public override DataApi Repository { get; set; } = new BallRepository();

        public override int BoardWitdth => boardWidth;

        public override int BoardHeight => boardHeight;

        public override List<ILogicBall> LogicBalls { get => logicBalls; set => logicBalls = value; }
        public override LoggingApi JsonLogger { get => jsonLogger; }

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
            ILogicBall logicBall = ILogicBall.Instantiate(ball);
            bool addable = true;
            foreach (ILogicBall LogicBallFromList in LogicBalls)
            {
                if (CalcDistance(logicBall, LogicBallFromList) <= radius * 2) { addable = false; break; }
            }
            if (addable)
            {
                Repository.AddBall(ball);
                LogicBalls.Add(logicBall);
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
            return Repository.Balls!;
        }

        public override void RemoveAllBalls()
        {
            LogicBalls.Clear();
            Repository.RemoveAllBalls();
        }

        public override int GetRepositroyListSize()
        {
            return Repository.GetAmountOfBalls();
        }

        public override async void StartLogging()
        {
            string date = DateTime.Now.ToString("hh_mm_ss-dd_MM_yyyy");
            jsonLogger = LoggingApi.Instatiate("..\\..\\..\\..\\Logs\\logs" + date + ".json");
            while (true)
            {
                await Task.Run(() => { JsonLogger.Write(); Thread.Sleep(1000);});
                
                if (flag)
                {
                    break;
                }
            }
        }

        public override async void StartBallsMovement()
        {
            flag = false;
            Vector2 vector = new Vector2(boardWidth, boardHeight);
            foreach (ILogicBall ball in LogicBalls)
            {
                ball.SetBoundries(vector);
            }

            while (true)
            {
                await Task.Run(() => { MoveTasks(); Thread.Sleep(16); Check(); });
                if (flag)
                {
                    break;
                }
            }

        }

        private async void MoveTasks()
        {
            Vector2 vector = new Vector2(boardWidth, boardHeight);
            foreach (ILogicBall ball in LogicBalls)
            {
                await Task.Run(() =>
                {
                    ball.Move();
                });
            }
        }

        public override float CalcDistance(ILogicBall a, ILogicBall b)
        {
            return (float)Math.Sqrt((a.Position_X - b.Position_X) * (a.Position_X - b.Position_X) + (a.Position_Y - b.Position_Y) * (a.Position_Y - b.Position_Y));
        }

        public override void HandleCollision(ILogicBall a, ILogicBall b)
        {
            float Vx1, Vy1, Vx2, Vy2;

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
            for (int i = 0; i < LogicBalls.Count; i++)
            {
                lock (LogicBalls[i])
                {
                    for (int j = i + 1; j < LogicBalls.Count; j++)
                    {
                        lock (LogicBalls[j])
                        {
                            if (CalcDistance(LogicBalls[i], LogicBalls[j]) <= 2 * LogicBalls[i].Radius)
                            {
                                JsonLogger.LogCollision(LogicBalls[i], LogicBalls[j]);
                                HandleCollision(LogicBalls[i], LogicBalls[j]);
                            }
                        }
                    }
                }

            }
        }

        public override void StopBallsMovement()
        {
            flag = true;
            JsonLogger.Finish();
        }
    }
}
