using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorWithAttendanceDataTest
    {
        private AttendanceCalculator calc;
        [TestInitialize]
        public void Init()
        {
            calc = new AttendanceCalculator();
        }

        [TestMethod]
        public void Should_load_attandance_data()
        {
            var attData = new AttendanceData { Regular = 1, Remark = 2 };
            var statementFalse = "iif(Regular=2,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementFalse, attData));
            var statementAttTrue = "iif(Regular=1 && Remark=2,1,2)";
            Assert.AreEqual(1, calc.Calculate(statementAttTrue, attData));
        }

    }
}
