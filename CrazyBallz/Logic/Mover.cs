using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    internal class Mover : IMover
    {
        private IBall? ball;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private Vector2 boardSize;

        public Mover(IBall? ball, Vector2 boardSize)
        {
            Ball = ball;
            BoardSize = boardSize;
        }

        public override IBall Ball { get => ball; set => ball = value; }
       
        public override Vector2 BoardSize { get => boardSize; set => boardSize = value; }

        public override void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        public override void ChangeXdirection()
        {
            ball.ChangeXdirection();
        }

        public override void ChangeYdirection()
        {
            ball.ChangeYdirection();
        }

        public override void Move()
        {
            lock (ball)
            {
                if (ball.Position_X + ball.Speed_X >= boardSize[0] - ball.Radius || ball.Position_X + ball.Speed_X <= ball.Radius)
                {
                    ChangeXdirection();
                }
                if (ball.Position_Y + ball.Speed_Y >= boardSize[1] - ball.Radius || ball.Position_Y + ball.Speed_Y <= ball.Radius)
                {
                    ChangeYdirection();
                }
                ball.Position_X += ball.Speed_X;
                ball.Position_Y += ball.Speed_Y;
            }            
        }

        public async Task MoveContinously()
        {
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                Move();
                await Task.Delay(16);
            }
        }
    }
}
