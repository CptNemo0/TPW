using System.Numerics;

namespace Tests
{
    internal class BallTests
    {
        IBall ball1;
        IBall ball2;
        Vector2 vector;
        [SetUp]
        public void Setup()
        {
            ball1 = IBall.CreateBall(0, 0, 5, 1, 1);
            ball2 = IBall.CreateBall(5, 5, 10, 3, 3);
            Vector2 vector = new Vector2(400, 400);
            ball1.BoardSize = vector;
            ball2.BoardSize = vector;
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(ball1.Position_X, Is.EqualTo(0)); 
            Assert.That(ball1.Position_Y, Is.EqualTo(0)); 
            Assert.That(ball1.Radius, Is.EqualTo(5)); 
            Assert.That(ball1.Speed_X, Is.EqualTo(1)); 
            Assert.That(ball1.Speed_Y, Is.EqualTo(1));
        }
        [Test]
        public void MoveTest()
        {
            Assert.That(ball1.Position_X, Is.EqualTo(0));
            Assert.That(ball1.Position_Y, Is.EqualTo(0));
            Assert.That(ball2.Position_X, Is.EqualTo(5));
            Assert.That(ball2.Position_Y, Is.EqualTo(5));
            ball1.Move(vector);
            ball2.Move(vector);
            Assert.That(ball1.Position_X, Is.EqualTo(1));
            Assert.That(ball1.Position_Y, Is.EqualTo(1));
            Assert.That(ball2.Position_X, Is.EqualTo(8));
            Assert.That(ball2.Position_Y, Is.EqualTo(8));
            ball1.Move(vector);
            ball2.Move(vector);
            Assert.That(ball1.Position_X, Is.EqualTo(2));
            Assert.That(ball1.Position_Y, Is.EqualTo(2));
            Assert.That(ball2.Position_X, Is.EqualTo(11));
            Assert.That(ball2.Position_Y, Is.EqualTo(11));
        }
    }
}
