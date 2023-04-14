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
            ball1 = IBall.CreateBall(5, 5, 5, 1, 1);
            ball2 = IBall.CreateBall(390, 390, 10, 3, 3);
            Vector2 vector = new Vector2(400, 400);
            ball1.BoardSize = vector;
            ball2.BoardSize = vector;
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

        [Test]
        public void MoveTest()
        {
            Assert.That(ball1.Position_X, Is.EqualTo(5));
            Assert.That(ball1.Position_Y, Is.EqualTo(5));
            ball1.Move(vector);
            Assert.That(ball1.Position_X, Is.EqualTo(6));
            Assert.That(ball1.Position_Y, Is.EqualTo(6));
            ball1.Move(vector);
            Assert.That(ball1.Position_X, Is.EqualTo(7));
            Assert.That(ball1.Position_Y, Is.EqualTo(7));
        }

        [Test]
        public void ChangeDirectionTest()
        {
            Assert.That(ball1.Position_X, Is.EqualTo(5));
            Assert.That(ball1.Position_Y, Is.EqualTo(5));
            ball1.Speed_X = -1;
            ball1.Speed_Y = -1;
            Assert.That(ball2.Position_X, Is.EqualTo(390));
            Assert.That(ball2.Position_Y, Is.EqualTo(390));
            ball1.Move(vector);
            ball2.Move(vector);
            Assert.That(ball1.Position_X, Is.EqualTo(6));
            Assert.That(ball1.Position_Y, Is.EqualTo(6));
            Assert.That(ball2.Position_X, Is.EqualTo(387));
            Assert.That(ball2.Position_Y, Is.EqualTo(387));
        }

        [Test]
        public void StartMovemntTest()
        {
            ball1.StartMovement(vector);
            Assert.That(ball1.Timer, Is.Not.Null);
            Assert.That(ball1.Position_X, Is.Not.EqualTo(5));
            Assert.That(ball1.Position_Y, Is.Not.EqualTo(5));
            ball1.Timer.Dispose();
        }
    }
}
