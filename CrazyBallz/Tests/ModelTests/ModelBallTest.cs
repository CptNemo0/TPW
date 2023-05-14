namespace ModelTests
{
    internal class ModelBallTest
    {
        IModelBall ball1;
        IModelBall ball2;
        [SetUp]
        public void SetUp()
        {
            ball1 = IModelBall.Instantiate(5, 5, 5);
            ball2 = IModelBall.Instantiate(10, 10, 10);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(ball1.Colour, Is.EqualTo(String.Empty));
            Assert.That(ball1.Position_X, Is.EqualTo(5));
            Assert.That(ball1.Position_Y, Is.EqualTo(5));
            Assert.That(ball1.Radius, Is.EqualTo(5));
            Assert.That(ball2.Colour, Is.EqualTo(String.Empty));
            Assert.That(ball2.Position_X, Is.EqualTo(10));
            Assert.That(ball2.Position_Y, Is.EqualTo(10));
            Assert.That(ball2.Radius, Is.EqualTo(10));
        }

        [Test]
        public void SetterTests()
        {
            ball1.Position_X = 10;
            ball1.Position_Y = 10;
            ball1.DetermineColour(1);
            Assert.That(ball1.Colour, Is.Not.EqualTo(String.Empty));
            Assert.That(ball1.Position_X, Is.EqualTo(10));
            Assert.That(ball1.Position_Y, Is.EqualTo(10));
        }
    }
}
