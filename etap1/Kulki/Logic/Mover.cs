using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Mover
    {
        private Random rng;
        private BoundsKeeper boundsKeeper;

        public Mover(BoundsKeeper collisionChecker) 
        {
            this.rng = new Random();
            this.boundsKeeper = collisionChecker;
        }

        public void moveBall(Ball ball, Vector2 vector) 
        {
            ball.X = (int)vector.X;
            ball.Y = (int)vector.Y;
        }

        public Vector2 getRandomMove(Ball ball)
        {
            Vector2 vector = new Vector2();

            do
            {
                vector.X = (int)ball.X;
                vector.X += rng.Next(0, 2) * ball.Velocity;
            } while(boundsKeeper.xIsInBounds((int)vector.X, ball.Radius));
            
            do
            {
                vector.Y = (int)ball.Y;
                vector.Y += rng.Next(0, 2) * ball.Velocity;
            } while (boundsKeeper.yIsInBounds((int)vector.Y, ball.Radius));

            return vector;
        }

        public void moveBallRandomly(Ball ball)
        {
            Vector2 randomMove = getRandomMove(ball);
            moveBall(ball, randomMove);
        }
    
        public void massiveRandomReposition(List<Ball> balls)
        {
            List<Ball> newPositions = balls;
            for (int i = 0; i < newPositions.Count; i++)
            { 
                moveBallRandomly(newPositions[i]);
            }
            balls = newPositions;
        }
    }
}
