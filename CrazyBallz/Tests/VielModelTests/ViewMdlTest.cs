namespace VielModelTests
{
    internal class ViewMdlTest
    {
        ViewMdl obj;
        [SetUp]
        public void SetUp()
        {
            obj = new ViewMdl();
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(obj.CommandStart, Is.Not.Null);
            Assert.That(obj.CommandReset, Is.Not.Null);
            Assert.That(obj.ModelApi, Is.Not.Null);
        }
    }
}
