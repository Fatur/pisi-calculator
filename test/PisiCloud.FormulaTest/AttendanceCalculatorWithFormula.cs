using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorWithFormula
    {
        private AttendanceCalculator calc;
        [TestInitialize]
        public void Init()
        {
            calc = new AttendanceCalculator();
        }

        [TestMethod]
        public void Should_load_attandance_load_formulas()
        {
            var attData = new AttendanceData { Regular = 1, Remark = 2 };
            var attFormula = new AttendanceFormula { OT = "iif(Regular=2,1,2)", OT1 = "iif(Regular=1 && Remark=2,1,2)" };
            AttendanceCalculationResult result = calc.Calculate(attFormula, attData);
            Assert.AreEqual(2, result.OT);
            Assert.AreEqual(1, result.OT1);
        }

    }
}
