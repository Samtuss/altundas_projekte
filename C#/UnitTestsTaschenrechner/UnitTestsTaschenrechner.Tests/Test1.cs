using UnitTestsTaschenrechner;
namespace UnitTestsTaschenrechner.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void Addiere_ZweiZahlen_KorrekteSumme()
        {
            // Arrange
            Rechner rechner = new Rechner();
            int zahl1 = 4, zahl2 = 5;
            // Act
            int expected = zahl1 + zahl2;
            int actual = rechner.Addiere(zahl1, zahl2);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Subtrahiere_ZweiZahlen_KorrekteSumme()
        {
            // Arrange
            Rechner rechner = new Rechner();
            int zahl1 = 10, zahl2 = 52;
            // Act
            int expected = zahl1 - zahl2;
            int actual = rechner.Subtrahiere(zahl1, zahl2);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MultipliziereTest()
        {
            // Arrange
            Rechner rechner = new Rechner();
            int zahl1 = 5;
            int zahl2 = 12;
            // Act
            int expected = zahl1 * zahl2;
            int ergebnis = rechner.Multipliziere(zahl1, zahl2);
            // Assert
            Assert.AreEqual(expected, ergebnis);
        }
        [TestMethod()]
        public void DividiereTest()
        {
            // Arrange
            Rechner rechner = new Rechner();
            int zahl1 = 52;
            int zahl2 = 5;
            // Act
            double expected = zahl1 / zahl2;
            double ergebnis = rechner.Dividiere(zahl1, zahl2);
            // Assert
            Assert.AreEqual(expected, ergebnis);
        }
    }
}
