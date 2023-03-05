namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void prostokatTest()
        {
            Figura figura = new Figura();
            double a = 2.0d;
            double b = 3.0d;
            double expected = 6.0d;
            double actuall = figura.prostokat(a, b);
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod]
        public void kwadratTest()
        {
            Figura figura = new Figura();
            double a = 2.0d;
            double expected = 2.0d;
            double actuall = figura.kwadrat(a);
            Assert.AreEqual(expected, actuall);
        } 

        [TestMethod]
        public void koloTest()
        {
            Figura figura = new Figura();
            double a = 2.0d;
            double expected = Math.PI * 4.0d;
            double actuall = figura.kolo(a);
            Assert.AreEqual(expected, actuall);
        }

        [TestMethod]
        public void trojkatTest()
        {
            Figura figura = new Figura();
            double a = 3.0d;
            double b = 4.0d;
            double c = 5.0d;
            double expected = 6.0d;
            double actuall = figura.trojkat(a, b, c);
            Assert.AreEqual(expected, actuall);
        }
    }
}