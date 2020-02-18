using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using Pisi.CalculatorRepository;

namespace Pisi.AttendanceCalculator.RepositoryTest
{
    [TestClass]
    public class StaticDataTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestLoadRemarkAsync()
        {
            IStaticDataRepository repo = new DapperStaticDataRepository();
            var result = await repo.LoadRemarkAsync();
            Assert.IsTrue(result.Count>0);

        }
    }
}
