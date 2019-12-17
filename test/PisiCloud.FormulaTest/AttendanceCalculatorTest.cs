using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorTest
    {
        private AttendanceCalculator calc;
        [TestInitialize]
        public void Init()
        {
            calc = new AttendanceCalculator();
        }

        [TestMethod]
        public void Should_init_pisi_functions()
        {
            var statementFalse = "iif(0,1,2)";
            Assert.AreEqual(2, calc.Calculate(statementFalse));
        }

        [TestMethod]
        public void Should_init_calculation_enggine()
        {
            Assert.AreEqual(7, calc.Calculate("2+5"));
            Assert.AreEqual(2, calc.Calculate("if(2==2,2,3)"));
        }
    }
}
