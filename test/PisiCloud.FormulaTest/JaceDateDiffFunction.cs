using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class JaceDateDiffFunctionTest
    {
        [TestMethod]
        public void TestDate1LessThanDate2()
        {
            var date1 = new DateTime(2020,1,1).Ticks;
            var date2 = new DateTime(2020, 1, 12).Ticks;
            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add("date1", date1);
            variables.Add("date2", date2);

            var statement = "if(DateDiff(date1,date2)==-1,1,0)";

            var calc = new Jace.CalculationEngine();
            calc.AddFunction("DateDiff", (a, b) => a <b?-1 :a==b? 0 : 1);
            Assert.AreEqual(1, calc.Calculate(statement, variables));
        }
        [TestMethod]
        public void TestDate1GreaterThanDate2()
        {
            var date1 = new DateTime(2020, 1, 13).Ticks;
            var date2 = new DateTime(2020, 1, 12).Ticks;
            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add("date1", date1);
            variables.Add("date2", date2);

            var statement = "if(DateDiff(date1,date2)==-1,1,0)";

            var calc = new Jace.CalculationEngine();
            calc.AddFunction("DateDiff", (a, b) => a < b ? -1 : a == b ? 0 : 1);
            Assert.AreEqual(0, calc.Calculate(statement, variables));
        }
    }
}
