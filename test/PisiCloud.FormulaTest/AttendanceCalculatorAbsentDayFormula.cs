using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;
namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorAbsentDayFormula
    {
        private AttendanceCalculator calc;
        private string mAbsenDayFormula = "iif((Regular=True AND Remark='ABSS') Or (Regular=True AND Remark='UPLl'),1,iif(Regular=True AND Remark='UP05',0.5,0))";
        //private string mAbsenDayFormula = "iif((Regular=True && Remark=1) || (Regular=2 && Remark=1),1,iif((Regular=1 && Remark=2) || (Regular=2 && Remark=1),1,2))";
        [TestInitialize]
        public void Init()
        {
            var staticDataMock = new Mock<IStaticDataRepository>();
            var listOfRemark = new List<Remark>()
            {
                new Remark(1,"ABSs"),
                new Remark(2,"UPLL"),
                new Remark(3,"UP05")
            };
            staticDataMock.Setup(m => m.LoadRemark()).Returns(listOfRemark);
            calc = new AttendanceCalculator();
            calc.LoadCompanyStaticDataAsConstant(staticDataMock.Object);
        }

        [TestMethod]
        public void Should_calcuate_absent_day()
        {
            var attData = new AttendanceData { Classification="CLS01",Regular = 1, Remark = 3 };
            var attFormula = new AttendanceFormula { AbsentDay= mAbsenDayFormula, OT = "iif(Regular=2,1,2)", OT1 = "iif(Regular=1 && Remark=2,1,2)" };
            var classMock = new Mock<IAttendanceClassification>();
            classMock.Setup(m => m.LoadFormulasById("CLS01")).Returns(attFormula);
            AttendanceCalculationResult result = calc.Calculate(classMock.Object, attData);
            Assert.AreEqual(0.5, result.AbsentDay);
        }

    }
}
