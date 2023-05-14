namespace VielModelTests
{
    internal class CommandoCommandoTest
    {
        Commando obj;

        [Test]
        public void ConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => obj = new Commando(null, null));
        }
    }
}
