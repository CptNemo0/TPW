namespace DataTests
{
    internal class BallRepositoryTests
    {
        DataApi Repository = DataApi.Instantiate();

        [SetUp]
        public void SetUp()
        {
            Repository.RemoveAllBalls();
            for (int i = 0; i < 5; i++)
            {
                Repository.AddBall(IBall.CreateBall(5, 5, 5, 1, 1, 1));
            }
        }

        [Test]
        public void GetBallsListTest()
        {
            Assert.That(Repository.Balls, Has.Count.EqualTo(5));
            for (int i = 0; i < Repository.Balls.Count; i++)
            {
                Assert.That(Repository.Balls[i].Position_X, Is.EqualTo(5));
                Assert.That(Repository.Balls[i].Position_Y, Is.EqualTo(5));
                Assert.That(Repository.Balls[i].Radius, Is.EqualTo(5));
                Assert.That(Repository.Balls[i].Speed_X, Is.EqualTo(1));
                Assert.That(Repository.Balls[i].Speed_Y, Is.EqualTo(1));
                Assert.That(Repository.Balls[i].Mass, Is.EqualTo(1));
            }
        }

        [Test]
        public void AddBallTest()
        {
            Repository.AddBall(IBall.CreateBall(5, 5, 5, 1, 1, 1));
            Assert.That(Repository.Balls, Has.Count.EqualTo(6));
            Assert.That(Repository.Balls[5].Position_X, Is.EqualTo(5));
            Assert.That(Repository.Balls[5].Position_Y, Is.EqualTo(5));
            Assert.That(Repository.Balls[5].Radius, Is.EqualTo(5));
            Assert.That(Repository.Balls[5].Speed_X, Is.EqualTo(1));
            Assert.That(Repository.Balls[5].Speed_Y, Is.EqualTo(1));
            Assert.That(Repository.Balls[5].Mass, Is.EqualTo(1));
        }

        [Test]
        public void RemoveBallTest()
        {
            Repository.RemoveBall(Repository.Balls[0]);
            Assert.That(Repository.Balls, Has.Count.EqualTo(4));
        }

        [Test]
        public void RemoveAllBallsTest()
        {
            Repository.RemoveAllBalls();
            Assert.That(Repository.Balls, Is.Empty);
        }

        [Test]
        public void GetAmountOfBallsTest()
        {
            Assert.That(Repository.GetAmountOfBalls(), Is.EqualTo(5));
            RemoveBallTest();
            Assert.That(Repository.GetAmountOfBalls(), Is.EqualTo(4));
        }
    }
}
