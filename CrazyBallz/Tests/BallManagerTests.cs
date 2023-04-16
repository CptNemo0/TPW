using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IBall ball = IBall.CreateBall(5, 5, 5, 1, 1);
            manager.GetBallRepositoryList().Add(ball);
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(1));
        }

        [Test]
        public void CreateBallTest()
        {
            manager.CreateBall(5, 5, 5, 1, 1);
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(1));
            for (int i = 0; i < 10000;  i++)
            {
                manager.CreateBallAtRandomCoordinates();
            }
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(10001));
            List<IBall> balls = manager.GetBallRepositoryList();
            for (int i = 0; i < 10000; i++)
            {
                Assert.That(balls[i].Position_X, Is.InRange(balls[i].Radius, manager.BoardWitdth - balls[i].Radius));
            }
        }

        [Test]
        public void RemoveAllBallsTest()
        {
            for (int i = 0; i < 10000; i++)
            {
                manager.CreateBallAtRandomCoordinates();
            }
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(10000));
            manager.RemoveAllBalls();
            Assert.That(manager.GetRepositroyListSize(), Is.EqualTo(0));
        }

        [Test]
        public void StartAndStopBallMovmentTest()
        {
            List<int> coordinatesX = new List<int>();
            List<int> coordinatesY = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                manager.CreateBallAtRandomCoordinates();
                coordinatesX.Add(manager.GetBallRepositoryList()[i].Position_X);
                coordinatesY.Add(manager.GetBallRepositoryList()[i].Position_Y);
            }
            manager.StartBallsMovement();
            for (int i = 0; i < manager.GetRepositroyListSize(); i++)
            {
                Thread.Sleep(70);
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
    }
}
