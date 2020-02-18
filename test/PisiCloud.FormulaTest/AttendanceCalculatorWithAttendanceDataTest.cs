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
        [TestMethod]
        public void Should_load_attandance_data_datein_dateout()
        {
            var attData = new AttendanceData { DateIn = new DateTime(2020,1,1,7,0,0), DateOut = new DateTime(2020,1,3,17,0,0) };
            var statement = "ifless(DateIn,DateOut,1,0)";
            Assert.AreEqual(1, calc.Calculate(statement, attData));
        }
        [TestMethod]
        public void Should_beable_to_get_date_of_datein_and_date_out()
        {
            var attData = new AttendanceData { DateIn = new DateTime(2020, 1, 1, 7, 0, 0), DateOut = new DateTime(2020, 1, 3, 17, 0, 0) };
            var statement = "DateOfDateOut-DateOfDateIn";
            var diff = TimeSpan.FromDays(2).Ticks;
            Assert.AreEqual(diff, calc.Calculate(statement, attData));
        }
        [TestMethod]
        public void Should_beable_to_get_time_of_datein_and_date_out()
        {
            var attData = new AttendanceData { DateIn = new DateTime(2020, 1, 1, 7, 0, 0), DateOut = new DateTime(2020, 1, 3, 17, 0, 0) };
            var statement = "TimeOfDateOut-TimeOfDateIn";
            var diff = TimeSpan.FromHours(10).Ticks;
            Assert.AreEqual(diff, calc.Calculate(statement, attData));
        }
        [TestMethod]
        public void Should_load_default_attandance_data_datein_dateout_if_null()
        {
            var attData = new AttendanceData();
            var statement = "ifless(DateIn,DateOut,1,0)";
            Assert.AreEqual(0, calc.Calculate(statement, attData));
        }
        [TestMethod]
        public void Should_get_isnull_true_if_datein_dateout_eq_null()
        {
            var attData = new AttendanceData();
            var statement1 = "IsNullDateIn";
            var statement2 = "IsNullDateOut";
            Assert.AreEqual(1, calc.Calculate(statement1, attData));
            Assert.AreEqual(1, calc.Calculate(statement2, attData));
        }
        [TestMethod]
        public void Should_get_isnull_not_true_if_datein_dateout_eq_not_null()
        {
            var attData = new AttendanceData() { DateIn = new DateTime(2020, 1, 1, 7, 0, 0) };
            var statement1 = "IsNullDateIn";
            var statement2 = "IsNullDateOut";
            Assert.AreEqual(0, calc.Calculate(statement1, attData));
            Assert.AreEqual(1, calc.Calculate(statement2, attData));
        }
        /* FROM 
         * iif((DateValue(DateTimeOut) > DateValue(DateTimeIn)) AND (TimeValue(DateTimeOut) >= TimeValue(#00:00#)) AND IsNull(DateTimeOut)=false, 1, 0)
         * TO:
         * iif((DateOut > DateIn) AND (TimeOfDateOut > 0) AND IsNullDateOut=1, 1, 0)
        */
        [TestMethod]
        public void Should_transform_datetime_to_dotnet_context()
        {
            var attData = new AttendanceData { DateIn = new DateTime(2020, 1, 1, 7, 0, 0), DateOut = new DateTime(2020, 1, 3, 17, 0, 0) };
            var statement = "iif((DateOut > DateIn) AND (TimeOfDateOut > 0) AND IsNullDateOut=0, 1, 0)";
            Assert.AreEqual(1, calc.Calculate(statement, attData));
        }
    }
}
