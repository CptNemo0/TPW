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
        private int BoardWidth;
        private readonly int BoardHeight;
        private DataApi repository;

        public override DataApi? Repository { get => repository; set => repository = value; }

        public BallManager(int boardWidth, int boardHeight) 
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            Repository = DataApi.Instantiate();
        }

        public override IBall CreateBall(int x, int y, int radius, int xSpeed, int ySpeed)
        {
            throw new NotImplementedException();
        }

        public override IBall CreateBallAtRandomCoordinates()
        {
            throw new NotImplementedException();
        }

        public override List<IBall> GetBallRepositoryList()
        {
            throw new NotImplementedException();
        }

        public override void RemoveAllBalls()
        {
            throw new NotImplementedException();
        }
    }
}
