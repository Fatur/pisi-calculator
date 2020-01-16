using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;
//iif((Regular=True AND Remark='ABS') Or (Regular=True AND Remark='UPL'),1,iif(Regular=True AND Remark='UP05',0.5,0))
namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorWithFormulaFromRepo
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
            var attData = new AttendanceData { Classification="CLS01",Regular = 1, Remark = 2 };
            var attFormula = new AttendanceFormula { OT = "iif(Regular=2,1,2)", OT1 = "iif(Regular=1 && Remark=2,1,2)" };
            var classMock = new Mock<IAttendanceClassification>();
            classMock.Setup(m => m.LoadFormulasById("CLS01")).Returns(attFormula);
            AttendanceCalculationResult result = calc.Calculate(classMock.Object, attData);
            Assert.AreEqual(2, result.OT);
            Assert.AreEqual(1, result.OT1);
        }

    }
}
