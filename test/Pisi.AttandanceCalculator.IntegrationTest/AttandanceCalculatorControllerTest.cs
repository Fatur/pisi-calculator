using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.CalculatorApi;
using Pisi.CalculatorApi.Requests;
using Pisi.CalculatorApi.Responses;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pisi.AttandanceCalculator.IntegrationTest
{
    /// <summary>
    /// Test ini harus terkoneksi dengan database demo pisi
    /// </summary>
    [TestClass]
    public class AttandanceCalculatorControllerTest
    {
        private  HttpClient mClient;
        [TestInitialize]
        public void Init()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            mClient = serverFactory.CreateClient();
        }
        [TestMethod]
        public async Task Calculate_penjumlahan_sederhana()
        {
            var calcRequest = new CalculateFormulaRequest
            {
                Formula="1+2"
            };
            var response = await mClient.PostAsJsonAsync("api/attendancecalculator/calculate",calcRequest);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result=await response.Content.ReadAsAsync<FormulaCalculatedResponse>();
            result.Result.Should().Be(3);
        }
        [TestMethod]
        public async Task Calculate_formula_dengan_data_attandance()
        {
            var calcRequest = new CalculateFormulaRequest
            {
                Formula = "iif((DateOut > DateIn) AND (TimeOfDateOut > 0) AND IsNullDateOut=0, 1, 0)",
                Attandance= new Attendance { DateIn = new DateTime(2020, 1, 1, 7, 0, 0), DateOut = new DateTime(2020, 1, 3, 17, 0, 0) }
            };
            var response = await mClient.PostAsJsonAsync("api/attendancecalculator/calculate", calcRequest);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<FormulaCalculatedResponse>();
            result.Result.Should().Be(1);
        }
        [TestMethod]
        public async Task Calculate_formula_yang_mengandung_remarkId()
        {
            var calcRequest = new CalculateFormulaRequest
            {
                Formula = "iif(Remark = AL05,2,1)",
                Attandance = new Attendance { DateIn = new DateTime(2020, 1, 1, 7, 0, 0),
                                                  DateOut = new DateTime(2020, 1, 3, 17, 0, 0),
                                                  Remark="Al05"
                }
            };
            var response = await mClient.PostAsJsonAsync("api/attendancecalculator/calculate", calcRequest);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<FormulaCalculatedResponse>();
            result.Result.Should().Be(2);
        }
    }
}
