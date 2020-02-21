using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using Pisi.CalculatorRepository;

namespace Pisi.AttendanceCalculator.RepositoryTest
{
    [TestClass]
    public class StaticDataTest
    {
        private IConfiguration configuration;
        [TestInitialize]
        public void Init()
        {
            configuration = InitConfiguration();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestLoadRemarkAsync()
        {
            IStaticDataRepository repo = new DapperStaticDataRepository(configuration);
            var result = await repo.LoadRemarkAsync();
            Assert.IsTrue(result.Count>0);

        }
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }

}
