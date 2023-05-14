using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicTests
{
    internal class LogicBallTests
    {
        IBall ball1;
        IBall ball2;
        LogicBall logicBall1;
        LogicBall logicBall2;

        [SetUp]
        public void Setup()
        {
            ball1 = IBall.CreateBall(5, 5, 5, 1, 1, 1);
            ball2 = IBall.CreateBall(390, 390, 10, 3, 3, 3);
            Vector2 vector = new Vector2(400, 400);
            logicBall1 = new LogicBall(ball1);
            logicBall2 = new LogicBall(ball2);
            logicBall1.SetBoundries(vector);
            logicBall2.SetBoundries(vector);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(logicBall1.Position_X, Is.EqualTo(5));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(5));
            Assert.That(logicBall1.Radius, Is.EqualTo(5));
            Assert.That(logicBall1.Speed_X, Is.EqualTo(1));
            Assert.That(logicBall1.Speed_Y, Is.EqualTo(1));
        }

        [Test]
        public void MoveTest()
        {
            Assert.That(logicBall1.Position_X, Is.EqualTo(5));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(5));
            logicBall1.Move();
            Assert.That(logicBall1.Position_X, Is.EqualTo(6));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(6));
            logicBall1.Move();
            Assert.That(logicBall1.Position_X, Is.EqualTo(7));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(7));
        }

        [Test]
        public void ChangeDirectionTest()
        {
            Assert.That(logicBall1.Position_X, Is.EqualTo(5));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(5));
            logicBall1.Speed_X = -1;
            logicBall1.Speed_Y = -1;
            Assert.That(logicBall2.Position_X, Is.EqualTo(390));
            Assert.That(logicBall2.Position_Y, Is.EqualTo(390));
            logicBall1.Move();
            logicBall2.Move();
            Assert.That(logicBall1.Position_X, Is.EqualTo(6));
            Assert.That(logicBall1.Position_Y, Is.EqualTo(6));
            Assert.That(logicBall2.Position_X, Is.EqualTo(387));
            Assert.That(logicBall2.Position_Y, Is.EqualTo(387));
        }
    }
}
