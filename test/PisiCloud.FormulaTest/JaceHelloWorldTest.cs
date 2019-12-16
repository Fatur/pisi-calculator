using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class JaceHelloWorldTest
    {
        [TestMethod]
        public void TestPenjumlahan()
        {
            var statement = "2+5";
            var calc = new Jace.CalculationEngine();
            Assert.AreEqual(7, calc.Calculate(statement));
        }
    }
}
