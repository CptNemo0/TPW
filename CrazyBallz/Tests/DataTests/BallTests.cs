using System.Numerics;

namespace Tests
{
    internal class BallTests
    {
        IBall ball1;
        [SetUp]
        public void Setup()
        {
            ball1 = IBall.CreateBall(5, 5, 5, 1, 1, 1);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(ball1.Position_X, Is.EqualTo(5));
            Assert.That(ball1.Position_Y, Is.EqualTo(5));
            Assert.That(ball1.Radius, Is.EqualTo(5));
            Assert.That(ball1.Speed_X, Is.EqualTo(1));
            Assert.That(ball1.Speed_Y, Is.EqualTo(1));
        }
    }
}
