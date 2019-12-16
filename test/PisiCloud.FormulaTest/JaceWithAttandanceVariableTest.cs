using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class JaceWithAttandanceVariableTest
    {
        [TestMethod]
        public void TestCalculateFromVariableOnly()
        {
            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("OTHour", 4);
            attandance.Add("OT1", 2);
            var calc = new Jace.CalculationEngine();
            var statement = "OTHour*OT1";
            Assert.AreEqual(8, calc.Calculate(statement,attandance));
        }
        [TestMethod]
        public void TestIfStatement()
        {
            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("OTHour", 1);
            attandance.Add("OT", 1);
            var statement = "if(OTHour==OT,1,2)";
            var calc = new Jace.CalculationEngine();
            Assert.AreEqual(1, calc.Calculate(statement, attandance));

        }
        [TestMethod]
        public void Test_IIF_Function()
        {
            var calc = new Jace.CalculationEngine();
            calc.AddFunction("iif", (a, b, c) => a != 0.0? b: c);
            var statementFalse = "iif(0,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementFalse));
            var statementTrue = "iif(1,1,2)";
            Assert.AreEqual(1, calc.Calculate(statementTrue));

            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("Regular", 1);

            var statementAttTrue = "iif(Regular==1,1,2)";
            Assert.AreEqual(1, calc.Calculate(statementAttTrue,attandance));
            attandance.Clear();
            attandance.Add("Regular", 0);
            var statementAttFalse = "iif(Regular==1,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementAttFalse, attandance));
        }
        [TestMethod]
        public void Test_IIF_Function_with_variable()
        {
            var calc = new Jace.CalculationEngine();
            calc.AddFunction("iif", (a, b, c) => a != 0.0 ? b : c);
            
            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("Regular", 1);

            var statementAttTrue = "iif(Regular==1,1,2)";
            Assert.AreEqual(1, calc.Calculate(statementAttTrue, attandance));
            attandance.Clear();
            attandance.Add("Regular", 0);
            var statementAttFalse = "iif(Regular==1,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementAttFalse, attandance));
        }
        [TestMethod]
        public void Test_IIF_Function_with_and_operator()
        {
            var calc = new Jace.CalculationEngine();
            calc.AddFunction("iif", (a, b, c) => a != 0.0 ? b : c);
            
            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("Regular", 1);
            attandance.Add("Remark", 1);
            attandance.Add("AL", 1);

            var statementAttTrue = "iif(Regular==1 && Remark==AL,1,2)";
            Assert.AreEqual(1, calc.Calculate(statementAttTrue, attandance));
            attandance["Remark"]= 0;
            var statementAttFalse = "iif(Regular==1 && Remark==AL,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementAttFalse, attandance));
        }
    }
}
