using Data;

namespace ModelTests
{
    internal class ModelManagerTest
    {
        ModelApi manager;
        [SetUp]
        public void SetUp()
        {
            manager = ModelApi.Instantiate();
        }

        [Test]
        public void CreateAndRemoveBallsTest()
        {
            manager.NewRandomBalls(10);
            Assert.That(manager.ReloadResub().Count, Is.EqualTo(10));
            manager.RemoveAllBalls();
            Assert.That(manager.ReloadResub().Count, Is.EqualTo(0));
        }

        [Test]
        public void StopAndStartMovemntTest()
        {
            List<float> Xs = new List<float>();
            List<float> Ys = new List<float>();
            manager.NewRandomBalls(10);
            foreach (IModelBall ball in manager.ReloadResub())
            {
                Xs.Add(ball.Position_X);
                Ys.Add(ball.Position_Y);
            }
            manager.StartBallsMovement();
            int i = 0;
            foreach (IModelBall ball in manager.ReloadResub())
            {
                Thread.Sleep(70);
                Assert.That(ball.Position_X, Is.Not.EqualTo(Xs[i]));
                Assert.That(ball.Position_Y, Is.Not.EqualTo(Ys[i]));
                i++;
            }
            Xs.Clear();
            Ys.Clear();
            manager.StopBallsMovement();
            foreach (IModelBall ball in manager.ReloadResub())
            {
                Xs.Add(ball.Position_X);
                Ys.Add(ball.Position_Y);
            }
            i = 0;
            foreach (IModelBall ball in manager.ReloadResub())
            {
                Assert.That(ball.Position_X, Is.EqualTo(Xs[i]));
                Assert.That(ball.Position_Y, Is.EqualTo(Ys[i]));
                i++;
            }
        }
    }
}
