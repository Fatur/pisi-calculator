using Jace.Tokenizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class AttendanceCalculatorReloadRemarkConstansTest
    {
        private AttendanceCalculator calc;
        [TestInitialize]
        public async System.Threading.Tasks.Task InitAsync()
        {
            var staticDataMock = new Mock<IStaticDataRepository>();
            var listOfRemark = new List<Remark>()
            {
                new Remark(1,"ABSs"),
                new Remark(2,"AL")
            };
            staticDataMock.Setup(m => m.LoadRemarkAsync()).ReturnsAsync(listOfRemark);
            calc = new AttendanceCalculator();
            await calc.LoadCompanyStaticDataAsConstantAsync(staticDataMock.Object);
        }

        
        [TestMethod]
        public void Should_reload_remark_as_constant()
        {
            var attData = new AttendanceData { Remark =1 };
            Assert.AreEqual(2, calc.Calculate("iif(Remark = abss,2,1)",attData));
        }
        [TestMethod]
        public void Test_token_reader()
        {
            TokenReader reader = new TokenReader();
            var tokens=reader.Read("iif(Remark == abs,2,1)");

        }
    }
}
