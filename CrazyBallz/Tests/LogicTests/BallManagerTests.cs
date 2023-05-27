namespace Tests
{
    internal class BallManagerTests
    {
        LogicApi manager;

        [SetUp]
        public void SetUp()
        {
            manager = LogicApi.Instantiate(400, 400);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(manager, Is.InstanceOf<LogicApi>());
            Assert.That(manager.BoardWitdth, Is.EqualTo(400));
            Assert.That(manager.BoardHeight, Is.EqualTo(400));
            Assert.That(manager.Repository, Is.Not.Null);
        }

        [Test]
        public void GetRepositroyListAndSizeTest()
        {
            Assert.That(manager.GetBallRepositoryList(), Is.Not.Null);
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(0));
            IBall ball = IBall.CreateBall(5, 5, 5, 1, 1, 1);
            manager.GetBallRepositoryList().Add(ball);
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(1));
        }

        [Test]
        public void CreateBallTest()
        {
            manager.CreateBall(5, 5, 5, 1, 1, 1);
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(1));
            int i = 100;
            while (i > 0)
            {
                if (manager.CreateBallAtRandomCoordinates())
                {
                    i--;
                }
            }
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(101));
            List<IBall> balls = manager.GetBallRepositoryList();
            for (i = 0; i < 101; i++)
            {
                Assert.That(balls[i].Position_X, Is.InRange(balls[i].Radius, manager.BoardWitdth - balls[i].Radius));
            }
        }

        [Test]
        public void RemoveAllBallsTest()
        {
            int i = 100;
            while (i > 0)
            {
                if (manager.CreateBallAtRandomCoordinates())
                {
                    i--;
                }
            }
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(100));
            manager.RemoveAllBalls();
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(0));
        }

        [Test]
        public void StartAndStopBallMovmentTest()
        {
            List<float> coordinatesX = new List<float>();
            List<float> coordinatesY = new List<float>();
            int k = 0;
            while (k < 5)
            {
                if (manager.CreateBallAtRandomCoordinates())
                {
                    coordinatesX.Add(manager.GetBallRepositoryList()[k].Position_X);
                    coordinatesY.Add(manager.GetBallRepositoryList()[k].Position_Y);
                    k++;
                }
            }
            manager.StartBallsMovement();
            for (int i = 0; i < manager.GetRepositroyListSize(); i++)
            {
                Thread.Sleep(100);
                if (manager.GetBallRepositoryList()[i].Speed_X != 0)
                {
                    Assert.That(coordinatesX[i], Is.Not.EqualTo(manager.GetBallRepositoryList()[i].Position_X));
                }
                if (manager.GetBallRepositoryList()[i].Speed_Y != 0)
                {
                    Assert.That(coordinatesY[i], Is.Not.EqualTo(manager.GetBallRepositoryList()[i].Position_Y));
                }
            }
            manager.StopBallsMovement();
            for (int i = 0; i < 5; i++)
            {
                coordinatesX[i] = manager.GetBallRepositoryList()[i].Position_X;
                coordinatesY[i] = manager.GetBallRepositoryList()[i].Position_Y;
            }
            for (int i = 0; i < manager.GetRepositroyListSize(); i++)
            {
                Assert.That(coordinatesX[i], Is.EqualTo(manager.GetBallRepositoryList()[i].Position_X));
                Assert.That(coordinatesY[i], Is.EqualTo(manager.GetBallRepositoryList()[i].Position_Y));
            }
        }

        [Test]
        public void HandleCollsionTest()
        {
            IBall a_ball = IBall.CreateBall(10, 15, 5, 2, 4, 1);
            IBall b_ball = IBall.CreateBall(30, 35, 5, -3, -2, 1);
            ILogicBall a = ILogicBall.Instantiate(a_ball);
            ILogicBall b = ILogicBall.Instantiate(b_ball);
            float Vx1, Vy1, Vx2, Vy2;
            Vx1 = (a.Mass * a.Speed_X + b.Mass * b.Speed_X - b.Mass * (a.Speed_X - b.Speed_X)) / (a.Mass + b.Mass);
            Vy1 = (a.Mass * a.Speed_Y + b.Mass * b.Speed_Y - b.Mass * (a.Speed_Y - b.Speed_Y)) / (a.Mass + b.Mass);
            Vx2 = (a.Mass * a.Speed_X + b.Mass * b.Speed_X - a.Mass * (b.Speed_X - a.Speed_X)) / (a.Mass + b.Mass);
            Vy2 = (a.Mass * a.Speed_Y + b.Mass * b.Speed_Y - a.Mass * (b.Speed_Y - a.Speed_Y)) / (a.Mass + b.Mass);
            manager.HandleCollision(a, b);
            Assert.That(a.Speed_X, Is.EqualTo(Vx1));
            Assert.That(a.Speed_Y, Is.EqualTo(Vy1));
            Assert.That(b.Speed_X, Is.EqualTo(Vx2));
            Assert.That(b.Speed_Y, Is.EqualTo(Vy2));
        }

    }
}
